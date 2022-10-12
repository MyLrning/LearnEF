using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningEF.Models;

public class Duty
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Id")]
    public string Title { get; set; }

    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreateDate { get; set; }
    public virtual Category Category { get; set; }

    [NotMapped]
    public string Summary { get; set; }

}

public enum Priority
{
    High,
    Medium,
    Low
}

