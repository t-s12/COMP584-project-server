using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projModel;
using _584_bb_proj.Dto;
using System.IdentityModel.Tokens.Jwt;

namespace _584_bb_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<BaseballTeamsUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost ("Login")]
        public async Task<ActionResult> LogInAsync(Dto.LoginRequest request)
        {
            BaseballTeamsUser user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return Unauthorized("Error: Unknown User");
            }
            bool success = await userManager.CheckPasswordAsync(user, request.Password);
            if (!success) 
            {
                return Unauthorized("Error: Invalid Password");
            }

            JwtSecurityToken token = await jwtHandler.GetTokenAsync(user);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new LoginResult
            {
                Success = true,
                Message = "YOOOOOOOOOOOO",
                Token = tokenString
            });
        }
    }
}
