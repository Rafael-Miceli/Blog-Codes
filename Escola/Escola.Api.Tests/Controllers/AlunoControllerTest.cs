using Escola.Api.Controllers;
using Escola.Domain;
using Escola.Domain.Interfaces;
using Escola.Domain.Model;
using Escola.ViewModels;
using Moq;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Escola.Api.Tests.Controllers
{

    public class AlunoControllerTest
    {
        [Fact]
        public void Ao_Cadastrar_Um_Aluno_Aonde_Sua_Matricula_Eh_Unica_Selecionou_Um_Polo_Valido_Selecionou_Materias_Validas_Criou_O_Usuario_Corretamente_Entao_Retorne_201()
        {
            // Arrange
            AlunoVm alunoVm = new AlunoVm
            {
                Matricula = "12345678",
                Nome = "Rafael",
                Email = "rafael@teste.com",
                PoloSelecionadoId = 1,
                MateriasSelecionadasId = new List<int> { 1, 2, 3 }
            };

            var alunoRepoMock = new Mock<IAlunoRepo>();
            var materiaRepoMock = new Mock<IMateriaRepo>();
            var poloRepoMock = new Mock<IPoloRepo>();

            alunoRepoMock.Setup(x => x.BuscarPorMatricula(alunoVm.Matricula)).Returns((Aluno)null);
            materiaRepoMock.Setup(x => x.BuscarMateriasSelecionadas(It.IsAny<IEnumerable<int>>())).Returns(new List<Materia>
            {
                new Materia()
            });

            poloRepoMock.Setup(x => x.BuscarPoloSelecionado(alunoVm.PoloSelecionadoId)).Returns(new Polo());

            IAlunoService alunoService = new AlunoService(alunoRepoMock.Object);
            IMateriaService materiaService = new MateriaService(materiaRepoMock.Object);
            IPoloService poloService = new PoloService(poloRepoMock.Object);
            IUsuarioService usuarioService = new UsuarioService();
            IEmailService emailService = new EmailService();                        

            IAlunoFacade alunoFacade = new AlunoFacade(alunoService, materiaService, poloService, usuarioService, emailService);

            AlunoController sut = new AlunoController(alunoFacade);

            // Act
            var result = sut.Post(alunoVm);

            // Assert

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public void Fixture_Ao_Cadastrar_Um_Aluno_Aonde_Sua_Matricula_Eh_Unica_Selecionou_Um_Polo_Valido_Selecionou_Materias_Validas_Criou_O_Usuario_Corretamente_Entao_Retorne_201()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new ApiControllerConventions());

            AlunoVm alunoVm = fixture.Create<AlunoVm>();

            var alunoRepoMock = fixture.Freeze<Mock<IAlunoRepo>>();

            alunoRepoMock.Setup(x => x.BuscarPorMatricula(alunoVm.Matricula)).Returns((Aluno)null);
            
            IAlunoService alunoService = fixture.Create<AlunoService>();
            fixture.Inject(alunoService);
            IMateriaService materiaService = fixture.Create<MateriaService>();
            fixture.Inject(materiaService);
            IPoloService poloService = fixture.Create <PoloService>();
            fixture.Inject(poloService);
            IUsuarioService usuarioService = fixture.Create <UsuarioService>();
            fixture.Inject(usuarioService);
            IEmailService emailService = fixture.Create<EmailService>();
            fixture.Inject(emailService);

            IAlunoFacade alunoFacade = fixture.Create<AlunoFacade>();
            fixture.Inject(alunoFacade);

            AlunoController sut = fixture.Create<AlunoController>();

            // Act
            var result = sut.Post(alunoVm);

            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

    }
}
