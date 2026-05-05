using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CP2_DOTNET.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Especie { get; set; }

        [MaxLength(50)]
        public string Raca { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        public int TutorId { get; set; }

        [ForeignKey("TutorId")]
        [JsonIgnore]
        public Tutor? Tutor { get; set; }
    }
}