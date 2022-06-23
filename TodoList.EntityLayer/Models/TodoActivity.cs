using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.EntityLayer.Models
{
    [Table("tblTodoActivities")]
    public class TodoActivity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name area can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description area can't be empty")]
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
