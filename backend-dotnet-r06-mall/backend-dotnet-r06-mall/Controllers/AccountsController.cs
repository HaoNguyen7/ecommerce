using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authentication.Configuration;
using Authentication.Models.DTO.Incoming;
using Authentication.Models.DTO.Outgoing;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace backend_dotnet_r06_mall.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly BanHangServices _service;

        public AccountsController(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, BanHangServices service)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _service = service;
        }

        // Register Action
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto registrationDto)
        {
            // Check the model or obj is valid
            if (ModelState.IsValid)
            {
                // Check email existing
                var existingUser = await _userManager.FindByEmailAsync(registrationDto.Email);
                if (existingUser is not null)
                {
                    return BadRequest(
                        new UserRegistrationResponseDto()
                        {
                            Success = false,
                            Errors = new List<string>() {
                                "Email already in use"
                            }
                        }
                    );
                }

                // Add the user
                var newUser = new IdentityUser()
                {
                    Email = registrationDto.Email,
                    UserName = registrationDto.Email,
                    EmailConfirmed = true // Todo: send user to confirm email

                };

                // Add user to database
                var isCreated = await _userManager.CreateAsync(newUser, registrationDto.Password);
                if (!isCreated.Succeeded)
                {
                    return BadRequest(
                        new UserRegistrationResponseDto()
                        {
                            Success = false,
                            Errors = isCreated.Errors.Select(x => x.Description).ToList()
                        }
                    );
                }
                // Add Khach hang to db
                var _khachHang = new KhachHang();
                _khachHang.KhachHangId = new Guid(newUser.Id);
                _khachHang.TenKhachHang = registrationDto.TenKhachHang;
                _khachHang.Email = registrationDto.Email;

                _service.CreateKhachHang(_khachHang);

                // Create a jwt token
                var token = GenerateJwtToken(newUser);

                // return the new user
                return Ok(new UserRegistrationResponseDto()
                {
                    Success = true,
                    Token = token
                }
                );

            }
            else
            {
                return BadRequest(
                    new UserRegistrationResponseDto
                    {
                        Success = false,
                        Errors = new List<string>() {
                        "Invalid payload"
                    }
                    }
                );
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginDto)
        {
            if (ModelState.IsValid)
            {
                // Check email
                var existingUser = await _userManager.FindByEmailAsync(loginDto.Email);

                if (existingUser is null)
                {
                    return BadRequest(new UserLoginResponseDto()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid authentication request"
                        }
                    });
                }

                // Check password
                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, loginDto.Password);
                if (isCorrect)
                {
                    var jwtToken = GenerateJwtToken(existingUser);

                    return Ok(new UserLoginResponseDto()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new UserLoginResponseDto()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid authentication request"
                        }
                    });
                }
            }
            else
            {
                return BadRequest(
                    new UserRegistrationResponseDto
                    {
                        Success = false,
                        Errors = new List<string>() {
                        "Invalid payload"
                    }
                    }
                );
            }
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            // get the secret key
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[] {
                        new Claim("Id", user.Id),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    }
                    ),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )

            };

            // generate the security token
            var token = jwtHandler.CreateToken(tokenDescriptor);

            // convert the security obj token into a string
            var jwtToken = jwtHandler.WriteToken(token);

            return jwtToken;

        }
    }
}