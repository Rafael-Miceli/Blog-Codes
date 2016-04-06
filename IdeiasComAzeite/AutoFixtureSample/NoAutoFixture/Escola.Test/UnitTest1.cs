using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Escola.Test
{
    [TestClass]
    public class AlunoServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]        
        public void Dado_Um_Aluno_Quando_Criar_O_Mesmo_Se_A_Matricula_Ja_Existir_Deve_Levantar_Uma_Excecao()
        {
            //Arrange
            var alunoRepoMock = new Mock<IAlunoRepo>();
            var aluno = new Aluno
            {
                Nome = "Joao",
                Matricula = "123456"
            };

            alunoRepoMock.Setup(x => x.ExisteMatricula(aluno.Matricula)).Returns(true);

            var sut = new AlunoService(alunoRepoMock.Object);

            //Act
            sut.AdcionarAluno(aluno);

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_Um_Aluno_Quando_Criar_O_Mesmo_Se_A_Matricula_Nao_Existir_Deve_Criar_Com_Sucesso()
        {
            //Arrange
            var alunoRepoMock = new Mock<IAlunoRepo>();
            var aluno = new Aluno
            {
                Nome = "Joao",
                Matricula = "123456"
            };

            alunoRepoMock.Setup(x => x.ExisteMatricula(aluno.Matricula)).Returns(false);

            var sut = new AlunoService(alunoRepoMock.Object);

            //Act
            sut.AdcionarAluno(aluno);

            //Assert
            alunoRepoMock.Verify(x => x.CriarAluno(aluno), Times.Once);
        }
    }
}
