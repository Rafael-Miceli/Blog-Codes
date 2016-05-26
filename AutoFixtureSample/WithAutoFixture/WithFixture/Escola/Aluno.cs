using System.Collections.Generic;

namespace Escola
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
