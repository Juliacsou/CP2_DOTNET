using System.ComponentModel.DataAnnotations;

namespace CP2_DOTNET.Entities
{
    public class Tutor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        // Relacionamento: 1 Tutor tem vários Pets
        public ICollection<Pet>? Pets { get; set; }
    }
}