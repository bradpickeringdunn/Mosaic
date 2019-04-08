using Mosaic.DTO;
using Mosaic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mosaic.Domain.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task AddTask(string name, CancellationToken cancellationToken)
        {
            await _toDoRepository.AddTask(new ToDoItemDTO(name), cancellationToken).ConfigureAwait(false);
        }

        public async Task<IDictionary<int, ToDoItemDTO>> LoadItems(CancellationToken cancellationToken)
        {
            return await _toDoRepository.LoadTasks(cancellationToken).ConfigureAwait(false);
        }

        public async Task MarkAsDone(int id, bool status, CancellationToken cancellationToken)
        {
            await _toDoRepository.MarkAsDone(id, status, cancellationToken).ConfigureAwait(false);
        }

        public async Task RemoveTask(int id, CancellationToken cancellationToken)
        {
            await _toDoRepository.RemoveTask(id, cancellationToken).ConfigureAwait(false);
        }
    }
}
