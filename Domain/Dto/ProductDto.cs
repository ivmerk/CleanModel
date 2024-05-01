using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanModel.Domain.Dto; 

public class ProductDto :ModelBase
{
  [Required]
  [Column("name")]
  public string Name { get; set; } = string.Empty;

  public CategoryDto Category { get; set; } = new CategoryDto();
  public List<int> DimensionsAndWeights { get; set; } = new List<int>();
  public string Article { get; set; } = string.Empty;
  public string Marking { get; set; } = string.Empty;
  public bool IsAdult { get; set; } = false;
  public bool IsHandmade { get; set; } = false;
  public bool IsAvailable { get; set; } = false;
  public List<MaterialDto> Materials { get; set; } = new List<MaterialDto>();
  public List<PhotoAndVideoDto> PhotoAndVideos { get; set; } = new List<PhotoAndVideoDto>();
  public string? Description { get; set; } = string.Empty;
  public int Price { get; set; } = 0;
  public bool IsDiscount { get; set; } = false;
  public int? Discount { get; set; } = 0;
}
