

using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers{

    [Route("api/account")]
    public class AccountController : ControllerBase{
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager =  userManager;   
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto){
            try{
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var user = new User{
                    UserName = registerDto.Username,
                    Email = registerDto.EmailAddress,
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);
                if(createdUser.Succeeded){
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if(roleResult.Succeeded){
                        return Ok(new NewUserDto{
                            Username = user.UserName,
                            EmailAddress = user.Email,
                            Tokens = _tokenService.CreateToken (user)
                        });
                    }else{
                        return StatusCode(500, roleResult.Errors);
                    }
                }else{
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch(Exception ex){
                return StatusCode(500, ex.Message);
            }
        }
    }
}