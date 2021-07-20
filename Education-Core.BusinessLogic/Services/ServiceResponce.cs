using Domain.Interfaces.Services;
using System;

namespace Education_Core.BusinessLogic.Services
{
    public class ServiceResponce<J> : IServiceResponce<J>
    {
        public J Result { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }
        public bool IsSuccessfully { get; private set; }

        public void SetValidResponce(string message = "Done")
        {
            IsSuccessfully = true;
            Message = message;
        }

        public void SetValidResponce(J obj, string message = "Done")
        {
            Result = obj;
            IsSuccessfully = true;
            Message = message;
        }

        public void SetInvalidResponce(Exception e, string message = "Error")
        {
            Exception = e;
            IsSuccessfully = false;
            Message = message;
        }
    }
}
