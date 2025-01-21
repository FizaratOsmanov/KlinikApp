using BL.DTOs;
using BL.Exceptions;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public  interface IDepartmentService
    {

        Task CreateDepartment(DepartmentPostDTO dto);


        Task<Department> GetDepartmentById(int id);


        Task<ICollection<DepartmentGetDTO>> GetAllDepartment();



        Task  UpdateDepartment(DepartmentPutDTO dto);

        Task  DeleteDepartment(int id);

        
       
    }
}
