using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanModel.Domain.Dto;

public class CategoryDto:ModelBase  
{
  [Required]
  [Column("name")]
  public string Name { get; set; } = string.Empty;
}
