using System;
using System.Net;
using BmesRestApi.Messages.Responses;

namespace BmesRestApi.Services
{
    public class ServiceBase
    {
        protected void WithErrorHandling(Action requestAction, ResponseBase response)
        {
            try
            {
                requestAction();
            }
            catch (Exception e)
            {
                var error = e.ToString();
                response.Messages.Add(error);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
        }
    }
}
