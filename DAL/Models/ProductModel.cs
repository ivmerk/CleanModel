using System;
using System.ComponentModel.DataAnnotations;

namespace CleanModel.DAL.Models;

public class ProductModel
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  //pulic Category Category { get; set; };
  //public List<int> DimensionsAndWeigths { get; set; } = new List<int>();
  public string Article { get; set; } = string.Empty;
  public string Marking { get; set; } = string.Empty;
  public bool IsAdault { get; set; } = false;
  public bool IsHandmade { get; set; } = false;
  public bool IsAvailable { get; set; } = false;
  //public List<Material> Materials { get; set; } = new List<Material>();
  //public List<PhotoAndVideo> PhotoAndVideos { get; set; } = new List<PhotoAndVideo>();
  public string? Description { get; set; } = string.Empty;
  public int Price { get; set; } = 0;
  public bool IsDiscount { get; set; } = false;
  public int? Discount { get; set; } = 0;
}
