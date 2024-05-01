using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanModel.Domain.Dto;

public class ModelBase
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_private")]
    public long PrivateId { get; set; }

    [Required]
    [Column("id_public")]
    public Guid PublicID { get; set; }
}


