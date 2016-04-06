namespace Escola
{
    public interface IAlunoRepo
    {
        bool ExisteMatricula(string matricula);
        void CriarAluno(Aluno aluno);
    }
}