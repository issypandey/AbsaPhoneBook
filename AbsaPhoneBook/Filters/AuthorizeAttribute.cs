using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AbsaPhoneBook.Filters
{
    public class AuthorizeCheck : TypeFilterAttribute
    {
        public AuthorizeCheck(bool urlIdCheck, bool bodyIdCheck) : base(typeof(AuthorizeCheckImpl))
        {
            Arguments = new object[] { urlIdCheck, bodyIdCheck };
        }
    }

    public class AuthorizeCheckImpl : IAuthorizationFilter
    {
        private bool UrlIdCheck { get; }
        private bool BodyIdCheck { get; }

        public AuthorizeCheckImpl(bool urlIdCheck, bool bodyIdCheck)
        {
            UrlIdCheck = urlIdCheck;
            BodyIdCheck = bodyIdCheck;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int id;
            if (BodyIdCheck)
            {
                string body = ReadBodyAsString(context.HttpContext.Request);
                if (!string.IsNullOrEmpty(body))
                {
                    var jsonBody = JObject.Parse(body);
                    id = int.Parse(jsonBody["id"]?.ToString());
                    if (true)
                    {
                        //go check if this id can insert or delete on that phonebook entry
                    }
                    else
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.Result = new JsonResult(new { HttpStatusCode.Forbidden });
                    }
                }
            }
            if (UrlIdCheck)
            {
                object value;
                if (context.RouteData.Values.TryGetValue("id", out value))
                {
                    id = int.Parse(value.ToString());
                    if (true)
                    {
                        //go check if this id can get that phonebook entry
                    }
                    else
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        context.Result = new JsonResult(new { HttpStatusCode.Forbidden });
                    }
                }
            }

        }


        public void OnActionExecuted(ActionExecutedContext context)
        {

        }



        private string ReadBodyAsString(HttpRequest request)
        {
            try
            {
                request.EnableBuffering();
                request.Body.Seek(0, System.IO.SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(
                    request.Body,
                    encoding: Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: false,
                    leaveOpen: true))
                {
                    string text = reader.ReadToEndAsync().Result;
                    return text;
                }
            }
            finally
            {
                request.Body.Position = 0;
            }
        }
    }
}
