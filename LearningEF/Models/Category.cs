using System.ComponentModel.DataAnnotations;

namespace LearningEF.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Duty> Duties { get; set; }

}


