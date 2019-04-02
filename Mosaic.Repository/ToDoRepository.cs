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
        private static IDictionary<int, ToDoItemDTO> ToDoTable;
        
        public async Task MarkAsDone(int id, bool status, CancellationToken cancellationToken)
        {
            Validate(id);
            await Task.Run(() =>ToDoTable[id].Done = status);
        }

        public async Task RemoveTask(int id, CancellationToken cancellationToken)
        {
            Validate(id);
            await Task.Run(() => ToDoTable.Remove(id));
        }

        public async Task AddTask(ToDoItemDTO task, CancellationToken cancellationToken)
        {
            var lastRecordId = ToDoTable.Last().Key;
            await Task.Run(() =>ToDoTable.Add(lastRecordId++, task));
        }

        public async Task<IDictionary<int,ToDoItemDTO>> LoadTasks(CancellationToken cancellationToken)
        {
            return await Task.FromResult(ToDoTable);
        }

        private void Validate(int id)
        {
            if(!ToDoTable.ContainsKey(id))
            {
                throw new Exception($"No record matching Id: {id} exists in the table.");
            }
        }
    }
}
