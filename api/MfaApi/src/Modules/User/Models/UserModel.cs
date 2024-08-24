using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MfaApi.Modules.User;

[Table("users")]
public class UserModel {
    [Column("id"), Key]
    public Guid Id { get; set; }

    [Column("email"), Required]
    public required string Email { get; set; }
    [Column("user_name"), Required]
    public required string UserName { get; set; }
}