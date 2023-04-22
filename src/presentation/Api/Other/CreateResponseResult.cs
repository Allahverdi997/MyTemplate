using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Other
{
    public static class CreateResponseResult
    {
        public static IActionResult CreateHttpResponseMessage(HttpStatusCode httpStatusCode, object content)
        {
            var response = new ObjectResult(content);
            response.StatusCode = (int)httpStatusCode;

            return response;
        }
    }
}
