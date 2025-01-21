using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public interface IAccountService
    {
        Task LoginAsync(LoginDTO dto);
        Task RegisterAsync(RegisterDTO dto);

        Task LogoutAsync();

    }
}
