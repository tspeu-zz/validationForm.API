using System.Net;

namespace pruebaJM.API.Controllers
{
    public class BadRequest : ApiError
    {
        public BadRequest(string v): base(400, HttpStatusCode.BadRequest.ToString())
        {
        }
    }
}