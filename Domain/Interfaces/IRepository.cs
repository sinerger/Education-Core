using System.Data;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        IDbConnection DBConnection { get; }
    }
}
