using AutoMapper;
using BL.DTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using CORE.Enums;
using Microsoft.AspNetCore.Identity;
namespace BL.Services.Implementations;

public class AccountService : IAccountService
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IMapper _mapper;
    public AccountService(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task RegisterAsync(RegisterDTO dto)
    {
        if (await _userManager.FindByNameAsync(dto.Username) is not null) throw new BaseException();
        if (await _userManager.FindByEmailAsync(dto.Email) is not null) throw new BaseException();

        IdentityUser user = _mapper.Map<IdentityUser>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new BaseException();
        }

        result = await _userManager.AddToRoleAsync(user, RoleEnum.User.ToString());

        if (!result.Succeeded)
        {
            throw new BaseException();
        }
    }

    public async Task LoginAsync(LoginDTO dto)
    {
        IdentityUser user =await _userManager.FindByNameAsync(dto.UserName) ?? throw new BaseException("Error");
        SignInResult result=await _signInManager.PasswordSignInAsync(user,dto.Password,dto.RememberMe,true);
        if (!result.Succeeded) 
        {
        throw new BaseException();
        }
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

}
