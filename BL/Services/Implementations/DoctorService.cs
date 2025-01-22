
using AutoMapper;
using BL.DTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DATA.Repositories.Abstractions;

namespace BL.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _repo;
        private readonly IRepository<Department> _departmentRepo;
        private readonly IMapper _mapper;
        
        public DoctorService(IRepository<Doctor> repo, IMapper mapper, IRepository<Department> departmentRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _departmentRepo = departmentRepo;
        }
        public async Task CreateDoctor(DoctorPostDTO dto)
        {

            if (await _departmentRepo.GetByIdAsync(dto.DepartmentId) is null) throw new BaseException();
            Doctor doctor = _mapper.Map<Doctor>(dto);
            await _repo.CreateAsync(doctor);
        }

        public async Task DeleteDoctor(int id)
        {
            Doctor doctor = await GetDoctorById(id);
            _repo.DeleteAsync(doctor);
            File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "Images","Doctors" ,doctor.ImagePath));
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
            if (dto.Image is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "Images", "Doctors", doctor.ImagePath));
        }


    }
}
