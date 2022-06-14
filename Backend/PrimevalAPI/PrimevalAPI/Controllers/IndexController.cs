using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimevalAPI.Models.Repository;
using PrimevalAPI.Services;
using System.Threading.Tasks;

namespace PrimevalAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class IndexController : Controller {
        public readonly ServicesRepository _services;
        public readonly ServicesToken _token;
        public IndexController(ServicesRepository services, ServicesToken token) {
            _services = services;
            _token = token;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult UserRegister(Repository User) {
                var result = _services._userRegister(User);
                if(result == false) {
                    return BadRequest();
                }
                else {
                    return Json(result);
                }
        }
                
            

        

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Repository>> UserLogin([FromBody] Repository User) {

            var validate = await _services._userLogin(User);
            if (validate == null) {
                return Json(validate);
            }

            var token = _token.GenerateToken(validate);
            validate.Password = "";
            return Json(validate.NickName + " , " + validate.Role + " , " + token);
        }


        [HttpGet]
        [Route("userAuthentication")]
        [Authorize]
        public void Authenticated() { }


        [HttpPost]
        [Route("lostpassValidate")]
        public async Task<bool> lostpassValidate(Repository UserEmail) {

            var result = _services._lostpassValidate(UserEmail);
            return result;
        }

        [HttpPost]
        [Route("resetPass")]

        public async Task<bool> resetPass(Repository User) {
            var result = _services._resetPass(User);
            if (result.Password == User.Password) {
                return true;
            }
            return false;
        }



    }
}
