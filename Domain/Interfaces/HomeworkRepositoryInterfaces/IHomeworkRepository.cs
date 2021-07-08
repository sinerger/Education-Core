﻿using Domain.Entities.Homeworks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.HomeworkRepositoryInterfaces
{
    public interface IHomeworkRepository : IRepository
    {
        Task<IEnumerable<Homework>> GetHomeworkAsync();
        Task<Homework> GetHomeworkByIdAsync(Guid id);
        Task<bool> CreateHomeworkAsync(Homework homework);
        Task<bool> UpdateHomeworkAsync(Homework homework);
        Task<bool> DeleteHomeworkAsync(Guid id);
    }
}
