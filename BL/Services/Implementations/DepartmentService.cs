using AutoMapper;
using BL.DTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Models;
using DATA.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IRepository<Department> _repo;
        private readonly IMapper _mapper;
        public DepartmentService(IRepository<Department> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task CreateDepartment(DepartmentPostDTO dto)
        {
            Department department = _mapper.Map<Department>(dto);
            await _repo.CreateAsync(department);

        }

        public async Task DeleteDepartment(int id)
        {
            Department department = await GetDepartmentById(id);
            _repo.DeleteAsync(department);
        }

        public async Task<ICollection<DepartmentGetDTO>> GetAllDepartment()
        {
            ICollection<Department> department=await _repo.GetAllAsync();
             ICollection<DepartmentGetDTO> DTOs=_mapper.Map<ICollection<DepartmentGetDTO>>(department); 
            return DTOs;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            Department department = await _repo.GetByIdAsync(id) ?? throw new BaseException();
            return department;
        }

        public async Task UpdateDepartment(DepartmentPutDTO dto)
        {
            Department oldDepartment = await GetDepartmentById(dto.Id);
            Department newDepartment=_mapper.Map<Department>(dto);
            if (newDepartment == null) { throw new BaseException(); }
            _repo.UpdateAsync(newDepartment);
        }


    }
}
