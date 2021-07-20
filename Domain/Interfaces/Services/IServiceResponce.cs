using System;

namespace Domain.Interfaces.Services
{
    public interface IServiceResponce<T>
    {
        T Result { get; }
        string Message { get; }
        Exception Exception { get; }
        bool IsSuccessfully { get; }

        void SetValidResponce(string message);
        void SetValidResponce(T obj, string message);
        void SetInvalidResponce(Exception e, string message);
    }
}
