using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Interfaces.HomeworkRepositoryInterfaces
{
    public interface IHomeworkUnitOfWork
    {
        IDbConnection DBConnection { get; set; }
        IHomeworkRepository HomeworkRepository { get; set; }

    }
}
