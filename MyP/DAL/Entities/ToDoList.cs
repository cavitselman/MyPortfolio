using System.ComponentModel.DataAnnotations;

namespace MyP.DAL.Entities
{
	public class ToDoList
	{
        [Key]
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
