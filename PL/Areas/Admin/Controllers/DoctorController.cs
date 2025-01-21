using AutoMapper;
using BL.DTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {

        private readonly IDoctorService _doctorService;
        private readonly IDepartmentService _departmentService;

        public DoctorController(IDoctorService doctorService,IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<DoctorGetDTO> dto =await  _doctorService.GetAllDoctor();
            return View(dto);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Department=await _departmentService.GetAllDepartment();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorPostDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                await _doctorService.CreateDoctor(dto);
                await _doctorService.Save();
                return RedirectToAction("Index");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError("Erro", ex.Message);
                return View(dto);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", "Doctor cannot created");
                return View(dto);
            }
        }
    }
}
