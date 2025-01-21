using BL.DTOs;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public  interface IDoctorService
    {
        Task CreateDoctor(DoctorPostDTO dto);
         

        Task<Doctor> GetDoctorById(int id);


        Task<ICollection<DoctorGetDTO>> GetAllDoctor();



        Task UpdateDoctor(DoctorPutDTO dto);

        Task DeleteDoctor(int id);

        Task<int> Save();
    }
}
