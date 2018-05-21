using ApplicationServices.Authentication;
using CrossCutting.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APICloseFriends.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        public IActionResult Post(
            [FromBody]User usuario,
            [FromServices]IAuthenticationService authenticationService
            )
        {
            try
            {
                dynamic authentication = authenticationService.Login(usuario);

                if (authentication.GetType().GetProperty("authenticated").GetValue(authentication))
                {
                    return new ObjectResult(authentication);

                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    authenticated = false,
                    message = "Ocorreu alguma excessão",
                    exception = ex.Message
                });
            }

        }
    }
}
