using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET.Business;
using RestWithASP_NET.Data.VO;
using RestWithASP_NET.Model;

namespace RestWithASP_NET.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]    
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        // POST api/values
        [HttpPost, AllowAnonymous]
        public object Post([FromBody]User user)
        {
            if (user == null) return BadRequest();
            return new ObjectResult(_loginBusiness.FindByLogin(user));
        }
    }
}
