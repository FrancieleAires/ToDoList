using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities
{
    public class Tasks
    {
        public int TaskId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get;  private set; }

        public Tasks()
        {

        }

        public Tasks(int taskId, string title, string description, DateTime creationDate)
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            CreationDate = creationDate;
        }


    }
}
