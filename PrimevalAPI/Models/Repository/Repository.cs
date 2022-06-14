using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimevalAPI.Models.Repository
{
    [Table("UserDB")]
    public class Repository
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int Id { get; set; }

        
        public string NickName { get; set; }

        
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string Role { get; set; }


    }
}
