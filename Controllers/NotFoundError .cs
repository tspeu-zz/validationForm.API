using System.Net;

namespace pruebaJM.API.Controllers
{
    public class NotFoundError : ApiError
    {
        public NotFoundError(string v)
            : base(404, HttpStatusCode.NotFound.ToString())
        {
        }


        // public InternalServerError(string message)
        //     : base(404, HttpStatusCode.NotFoundError.ToString(), message)
        // {
        // }
    
    }
}