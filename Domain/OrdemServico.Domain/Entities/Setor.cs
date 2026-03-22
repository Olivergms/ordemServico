
using System.ComponentModel.DataAnnotations;

namespace OrdemServico.Domain.Entities
{
    public class Setor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }
    }
}
