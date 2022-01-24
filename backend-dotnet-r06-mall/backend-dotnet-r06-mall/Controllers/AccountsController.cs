using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authentication.Configuration;
using Authentication.Models.DTO.Incoming;
using Authentication.Models.DTO.Outgoing;
using backend_dotnet_r06_mall.Contants;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using backend_dotnet_r06_mall.Requests;
using backend_dotnet_r06_mall.Response;
using backend_dotnet_r06_mall.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace backend_dotnet_r06_mall.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtConfig _jwtConfig;

        private readonly BanHangContext _context;

        public AccountsController
        (
            UserManager<IdentityUser> userManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            RoleManager<IdentityRole> roleManager,
            BanHangContext context

        )
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _roleManager = roleManager;
            _context = context;
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

                await _context.KhachHang.AddAsync(_khachHang);
                await _context.SaveChangesAsync();

                //Create Roles
                if (!await _roleManager.RoleExistsAsync(RoleConstants.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Admin));
                }
                if (!await _roleManager.RoleExistsAsync(RoleConstants.Khach))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleConstants.Khach));
                }
                if (!await _roleManager.RoleExistsAsync(RoleConstants.TaiXe))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleConstants.TaiXe));
                }
                if (!await _roleManager.RoleExistsAsync(RoleConstants.CuaHang))
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleConstants.CuaHang));
                }

                if (await _roleManager.RoleExistsAsync(RoleConstants.Khach))
                {
                    await _userManager.AddToRoleAsync(newUser, RoleConstants.Khach);
                }
                // Create a jwt token
                var userRoles = await _userManager.GetRolesAsync(newUser);
                var token = GenerateJwtToken(newUser, userRoles);

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
                    var userRoles = await _userManager.GetRolesAsync(existingUser);
                    var jwtToken = GenerateJwtToken(existingUser, userRoles);

                    return Ok(new UserLoginResponseDto()
                    {
                        Success = true,
                        Token = jwtToken, 
                        Email = loginDto.Email,
                        id = existingUser.Id.ToString()
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

        [HttpPut]
        [Route("change-password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword([FromBody] UserPasswordChangRequest request)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);
            var existingUser = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ChangePasswordAsync(existingUser, request.oldPassword, request.newPassword);
            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(existingUser);
                var jwtToken = GenerateJwtToken(existingUser, userRoles);
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
                    Errors = new List<string>() {
                        "Password change failed"
                    }

                });
            }
        }
        [HttpPost]
        [Route("grant-role-cuahang")]
        public async Task<IActionResult> addRoleCHtoUser(GrantRoleCHRequest query)
        {
            var existingUser = await _userManager.FindByIdAsync(query.id.ToString());

            if (await _roleManager.RoleExistsAsync(RoleConstants.CuaHang))
            {
                await _userManager.AddToRoleAsync(existingUser, RoleConstants.CuaHang);
            }
            return Ok("Success");
        }
        [HttpPut]
        [Route("change-email")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangeEmail([FromBody] String email)
        {
            Guid userId = new Guid(User.FindFirst("Id")?.Value);
            var existingUser = await _userManager.FindByIdAsync(userId.ToString());
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            token = token.Replace("Bearer ", "");
            System.Diagnostics.Debug.WriteLine(token);
            var result = await _userManager.ChangeEmailAsync(existingUser, email, token);
            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(existingUser);
                var jwtToken = GenerateJwtToken(existingUser, userRoles);
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
                    Errors = new List<string>() {
                        "Email change failed"
                    }

                });
            }
        }


        private string GenerateJwtToken(IdentityUser user, IList<string> roles)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            // get the secret key
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var subject = new ClaimsIdentity(
                    new[] {
                        new Claim("Id", user.Id),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    });

            foreach (var userRole in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, userRole));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
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