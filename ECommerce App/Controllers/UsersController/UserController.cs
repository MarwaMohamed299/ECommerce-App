using ECommerceBL.DTOs.Users;
using ECommerceDAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce_App.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("staticLogin")]
        public ActionResult<string> StaticLogin(LoginDto credentials)
        {
            if (credentials.DisplayName == "User" && credentials.Password == "pass")
            {
                var userClaims = new List<Claim>
                {
                    new Claim (ClaimTypes.NameIdentifier , credentials.DisplayName),
                    new Claim(ClaimTypes.Email , $"{credentials.DisplayName}@gmail.com"),
                    new Claim ("Nationality" ,"Egyptian")
                };
                //GenerateKey
                var SecretKey = _configuration.GetValue<string>("SecretKey");
                var secretKeyInBytes = Encoding.ASCII.GetBytes(SecretKey);
                var Key = new SymmetricSecurityKey(secretKeyInBytes);

                //Determine how to Generate Hashing Result
                var methodUsedInGeneratingToken = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);

                //GenerateTOKen 
                var jwt = new JwtSecurityToken(
                    claims: userClaims,
                    notBefore: DateTime.Now.AddMinutes(15),
                    signingCredentials: methodUsedInGeneratingToken
                    );

                var tokenHandler = new JwtSecurityTokenHandler();
                string tokenString = tokenHandler.WriteToken(jwt);

                return Ok(tokenString);
            }
            return Unauthorized("Wrong Credentials");

        }


        [HttpPost]
        [Route("login")]

   
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.DisplayName);

            if (user == null)
            {
                return BadRequest("User Not Found");
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                return BadRequest("Try Again");
            }

            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, credentials.Password);

            if (!isAuthenticated)
            {
                await _userManager.AccessFailedAsync(user);
                return Unauthorized("Wrong Credentials");

            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            // GenerateKey
            var SecretKey = _configuration.GetValue<string>("SecretKey");
            var secretKeyInBytes = Encoding.ASCII.GetBytes(SecretKey);
            var Key = new SymmetricSecurityKey(secretKeyInBytes);

            //Determine how to Generate Hashing Result
            var methodUsedInGeneratingToken = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
            var exp = DateTime.Now.AddMinutes(15);
            //GenerateTOKen 
            var jwt = new JwtSecurityToken(
                claims: userClaims,
                notBefore: DateTime.Now.AddMinutes(15),
                expires: exp,
                signingCredentials: methodUsedInGeneratingToken
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(jwt);


            var tokenDto = new TokenDto
            {
                Token = tokenString,
                ExpiryDate = exp
            };
            return Ok(tokenDto);




        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDto registerDto)
        {


            var passwordValidator = new PasswordValidator<User>();
            var result = await passwordValidator.ValidateAsync(_userManager, null, registerDto.Password);
            var errors = result.Errors.Select(e => new { code = e.Code, description = e.Description });


            if (result.Succeeded)
            {
                var NewUser = new User
                {
                    DisplayName = registerDto.DisplayName,
                    Email = registerDto.Email,
                    City = registerDto.City,
                    PasswordHash = registerDto.Password,
                };

                var creationResult = await _userManager.CreateAsync(NewUser, registerDto.Password);

                if (creationResult.Succeeded)
                {
                    return Ok("User Created Successfully");
                }
                else
                {
                    return BadRequest(creationResult);
                }
            }
            else
            {

                return BadRequest(result.Errors);
            }
        }


    }
}

 