using BL.DTOs;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controlers
{
    public class HomeController : Controller
    {
        readonly IDoctorService _service;
        public HomeController(IDoctorService service)
        {
             _service = service;
        }
        public async Task<IActionResult> Index()
        {

            ICollection<DoctorGetDTO> dto =await  _service.GetAllDoctor();
            return View();
        }
    }
}
