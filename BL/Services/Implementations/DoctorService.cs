
using AutoMapper;
using BL.DTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DATA.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;

namespace BL.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _repo;
        private readonly IRepository<Department> _departmentRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DoctorService(IRepository<Doctor> repo, IMapper mapper, IRepository<Department> departmentRepo,IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _repo = repo;
            _departmentRepo = departmentRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task CreateDoctor(DoctorPostDTO dto)
        {

            if (await _departmentRepo.GetByIdAsync(dto.DepartmentId) is null) throw new BaseException();
            Doctor doctor = _mapper.Map<Doctor>(dto);
            string rootPath = _webHostEnvironment.WebRootPath;
            string fileName = dto.Image.FileName;
            string folderPath = rootPath + "/UPLOAD/Doctors/";
            string filePath = Path.Combine(folderPath, fileName);

            bool exists = Directory.Exists(folderPath);

            if (!exists)
            {
                Directory.CreateDirectory(folderPath);
            }

            string[] allowedExtensions = [".png", ".jpg", ".jpeg"];
            bool isAllowed = false;
            foreach (string extention in allowedExtensions)
            {
                if (Path.GetExtension(fileName) == extention)
                {
                    isAllowed = true;
                    break;
                }
            }
            if (!isAllowed)
            {
                throw new Exception("File not supported");
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }
            doctor.ImagePath = fileName;

            await _repo.CreateAsync(doctor);
        }

        public async Task DeleteDoctor(int id)
        {
            Doctor doctor = await GetDoctorById(id);
            _repo.DeleteAsync(doctor);
        }


        public async Task<ICollection<DoctorGetDTO>> GetAllDoctor()
        {
            ICollection<Doctor> doctor = await _repo.GetAllAsync();
            ICollection<DoctorGetDTO> DTOs = _mapper.Map<ICollection<DoctorGetDTO>>(doctor);
            return DTOs;
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            Doctor doctor = await _repo.GetByIdAsync(id) ?? throw new BaseException();
            return doctor;
        }

        public async Task<int> Save()=>await _repo.SaveAsync();

 

        public async Task UpdateDoctor(DoctorPutDTO dto)
        {

            if (await _departmentRepo.GetByIdAsync(dto.DepartmentId) is null) throw new BaseException();

            Doctor doctor = await GetDoctorById(dto.Id);
            Doctor newDoctor=_mapper.Map<Doctor>(dto);

            if (newDoctor == null) throw new BaseException(); 
            
            _repo.UpdateAsync(newDoctor);
        }


    }
}
