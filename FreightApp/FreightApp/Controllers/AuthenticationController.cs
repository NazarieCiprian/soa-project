using FreightApp.Core.Dto;
using FreightApp.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightApp.Controllers
{
    [ApiController]
    [Route("rest/[controller]")]
    public class AuthenticationController: ControllerBase
    {
        private readonly AuthenticationHelper _authenticationHelper;
        public AuthenticationController(AuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Login([FromBody] AuthInput login)
        {
            var result = await _authenticationHelper.Authenticate(login.Username, login.Password);
            return Ok(result);

        }
    }
}
