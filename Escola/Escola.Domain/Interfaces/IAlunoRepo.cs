using Escola.Domain.Model;

namespace Escola.Domain.Interfaces
{
    public interface IAlunoRepo
    {
        Aluno BuscarPorMatricula(string matricula);
        void CadastrarAluno(Aluno aluno);
    }
}
