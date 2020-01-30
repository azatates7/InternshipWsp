using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    { 
        private readonly string[] users = new string[] { "A", "B", "C" };
        public string[] Get()
        {
            return users;
        }
    }
}