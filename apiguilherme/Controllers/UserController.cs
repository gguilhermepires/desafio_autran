using Guilherme.AppService.Interfaces;
using Guilherme.Service.Contracts.RequestResponse.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Guilherme.Commons.ClaimConfiguration.CustomAuthorization;

namespace ApiGuilherme.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        private readonly IUserAppService _appService;

        public UserController(IUserAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserRequest request)
        {
            var responseMessage = await _appService.LoginUserAsync(request);
            return StatusCode(responseMessage.StatusCode, responseMessage);
        }

        [HttpGet]
        [Route("testClaim")]
        [ClaimsAuthorize("Role", "adm")]

        public string Authenticated()
        {
            return string.Format("Autenticado - {0}", User.Identity.Name);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var responseMessage = await _appService.GetAllUsersAsync();
            return StatusCode(responseMessage.StatusCode, responseMessage);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByUserIdAsync(Guid id)
        {
            var responseMessage = await _appService.GetByUserIdAsync(id);
            return StatusCode(responseMessage.StatusCode, responseMessage);
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] UserRequest request)
        {
            var responseMessage = await _appService.AddUserAsync(request);
            return StatusCode(responseMessage.StatusCode, responseMessage);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UserRequest request, Guid id)
        {
            var responseMessage = await _appService.UpdateUserAsync(id, request);
            return StatusCode(responseMessage.StatusCode, responseMessage);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var responseMessage = await _appService.DeleteUserAsync(id);
            return StatusCode(responseMessage.StatusCode, responseMessage);
        }
    }
}