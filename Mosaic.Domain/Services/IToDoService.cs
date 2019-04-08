using Mosaic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mosaic.Domain.Services
{
    public interface IToDoService
    {
        Task MarkAsDone(int id, bool status, CancellationToken cancellationToken);
        Task RemoveTask(int id, CancellationToken cancellationToken);
        Task AddTask(string name, CancellationToken cancellationToken);
        Task<IDictionary<int, ToDoItemDTO>> LoadItems(CancellationToken cancellationToken);
    }
}
