using System.ComponentModel.DataAnnotations.Schema;

namespace CleanModel.Domain.Dto;

public class PhotoAndVideoDto: ModelBase
{
  [Column("url")]
  public string Url { get; set; } = string.Empty;

  [Column("media_type")]
  public MediaType MediaType { get; set; } = MediaType.Photo; 
}

    public enum MediaType
    {
        Photo,
        Video
    }
