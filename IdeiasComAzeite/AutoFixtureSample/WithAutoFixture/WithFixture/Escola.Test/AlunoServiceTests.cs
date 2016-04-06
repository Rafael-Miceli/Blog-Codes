using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System.Linq;

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
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var materiaServiceMock = fixture.Freeze<Mock<IMateriaService>>();
            var alunoRepoMock = fixture.Freeze<Mock<IAlunoRepo>>();

            alunoRepoMock.Setup(x => x.ExisteMatricula(It.IsAny<string>())).Returns(true);

            var aluno = fixture.Build<Aluno>().Without(a => a.Materias).Create();
            var sut = fixture.Create<AlunoService>();
            

            //Act
            sut.AdcionarAluno(aluno, null);

            //Assert
            materiaServiceMock.Verify(x => x.BuscarMateriaisSelecionados(It.IsAny<List<int>>()), Times.Never);
        }

        [TestMethod]
        public void Dado_Um_Aluno_Quando_Criar_O_Mesmo_Se_A_Matricula_Nao_Existir_Deve_Criar_Com_Sucesso()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var materiaServiceMock = fixture.Freeze<Mock<IMateriaService>>();
            var alunoRepoMock = fixture.Freeze<Mock<IAlunoRepo>>();

            alunoRepoMock.Setup(x => x.ExisteMatricula(It.IsAny<string>())).Returns(false);

            var aluno = fixture.Build<Aluno>().Without(a => a.Materias).Create();
            var materiasIdsSelecionadas = fixture.CreateMany<int>();
            var sut = fixture.Create<AlunoService>();
            
            //Act
            sut.AdcionarAluno(aluno, materiasIdsSelecionadas.ToList());

            //Assert
            materiaServiceMock.Verify(x => x.BuscarMateriaisSelecionados(It.IsAny<List<int>>()), Times.Once);
            alunoRepoMock.Verify(x => x.CriarAluno(aluno), Times.Once);
        }

        [TestMethod]
        public void Dado_Um_Aluno_Quando_Criar_Se_O_Mesmo_Selecionou_Materia_Deve_Criar_Com_Sucesso()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var materiaServiceMock = fixture.Freeze<Mock<IMateriaService>>();
            var alunoRepoMock = fixture.Freeze<Mock<IAlunoRepo>>();

            alunoRepoMock.Setup(x => x.ExisteMatricula(It.IsAny<string>())).Returns(false);
            materiaServiceMock.Setup(x => x.BuscarMateriaisSelecionados(It.IsAny<List<int>>())).Returns(new List<Materia>
            {
                new Materia()
            });

            var aluno = fixture.Build<Aluno>().Without(a => a.Materias).Create();
            var materiasIdsSelecionadas = fixture.CreateMany<int>();
            var sut = fixture.Create<AlunoService>();
            
            //Act
            sut.AdcionarAluno(aluno, materiasIdsSelecionadas.ToList());

            //Assert
            Assert.IsNotNull(aluno.Materias);
            Assert.IsTrue(aluno.Materias.Count > 0);
            materiaServiceMock.Verify(x => x.BuscarMateriaisSelecionados(It.IsAny<List<int>>()), Times.Once);
            alunoRepoMock.Verify(x => x.CriarAluno(aluno), Times.Once);
        }
    }
}
