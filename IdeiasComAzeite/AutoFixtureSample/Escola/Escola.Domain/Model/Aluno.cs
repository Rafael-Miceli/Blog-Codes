using System.Collections.Generic;

namespace Escola.Domain.Model
{
    public class Aluno
    {
        public string Email { get; internal set; }
        public IEnumerable<Materia> MateriasCursando { get; internal set; }
        public string Matricula { get; internal set; }
        public string Nome { get; internal set; }
        public Polo Polo { get; internal set; }
    }
}
