using LinkBilgisayarProject.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkBilgisayarProject.API.Controllers
{

    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response) //Herseferinde  ok badrequest vs. gibi return etmemek için 
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = response.StatusCode };
            }
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
