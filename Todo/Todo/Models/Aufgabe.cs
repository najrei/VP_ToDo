using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    public class Aufgabe
    {
        public int Id { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 10)]
        [Required (ErrorMessage = "Eine Aufgabe muss länger als 10 Zeichen sein.")]
        public string BeschreibungText { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AbgabeTime { get; set; }
        public bool Erledigt { get; set; }
    }

}
