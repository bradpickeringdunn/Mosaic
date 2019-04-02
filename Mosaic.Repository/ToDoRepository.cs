using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mosaic.DTO;

namespace Mosaic.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private static IDictionary<int, ToDoItemDTO> _toDoTable;

        public ToDoRepository()
        {
            if (_toDoTable == null || !_toDoTable.Any())
            {
                _toDoTable = new Dictionary<int, ToDoItemDTO>()
            {
                {1, new ToDoItemDTO("Complete tech test."){ Done=true} },
                {2, new ToDoItemDTO("Get to next stage of interview process.") }
            };
            }
        }

        public async Task MarkAsDone(int id, bool status, CancellationToken cancellationToken)
        {
            Validate(id);
            await Task.Run(() =>_toDoTable[id].Done = status);
        }

        public async Task RemoveTask(int id, CancellationToken cancellationToken)
        {
            Validate(id);
            await Task.Run(() => _toDoTable.Remove(id));
        }

        public async Task AddTask(ToDoItemDTO task, CancellationToken cancellationToken)
        {
            var lastRecordId = _toDoTable.Last().Key;
            await Task.Run(() =>_toDoTable.Add(lastRecordId+1, task));
        }

        public async Task<IDictionary<int,ToDoItemDTO>> LoadTasks(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_toDoTable);
        }

        private void Validate(int id)
        {
            if(!_toDoTable.ContainsKey(id))
            {
                throw new Exception($"No record matching Id: {id} exists in the table.");
            }
        }
    }
}
