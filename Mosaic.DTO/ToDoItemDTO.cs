using System;

namespace Mosaic.DTO
{
    public class ToDoItemDTO
    {
        private readonly string _name;

        public ToDoItemDTO(string name)
        {
            _name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public bool Done { get; set; }
    }
}
