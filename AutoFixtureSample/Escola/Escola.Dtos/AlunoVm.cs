using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.ViewModels
{
    public class AlunoVm
    {
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string Nome { get; set; }
        public IEnumerable<int> MateriasSelecionadasId { get; set; }
        [Required]
        public int PoloSelecionadoId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
