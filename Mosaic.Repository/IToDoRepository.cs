using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mosaic.DTO;

namespace Mosaic.Repository
{
    public interface IToDoRepository
    {
        Task AddTask(ToDoItemDTO task, CancellationToken cancellationToken);
        Task<IDictionary<int, ToDoItemDTO>> LoadTasks(CancellationToken cancellationToken);
        Task MarkAsDone(int id, bool status, CancellationToken cancellationToken);
        Task RemoveTask(int id, CancellationToken cancellationToken);
    }
}
