using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace WebApiWithStructureMap.Infrastructure.Exceptions
{
    public class GlobalExceptionHandler :
        ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error has occured. Please try again.")
            };
            context.Result = new DefaultExceptionResult(context.Request, result);
        }
    }
}