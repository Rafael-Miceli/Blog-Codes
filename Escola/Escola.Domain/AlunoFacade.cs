using Escola.Domain.Interfaces;
using Escola.Domain.Model;
using Escola.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Escola.Domain
{
    public class AlunoFacade: IAlunoFacade
    {
        private IAlunoService _alunoService;
        private IMateriaService _materiaService;
        private IPoloService _poloService;
        private IUsuarioService _usuarioService;
        private IEmailService _emailService;


        public AlunoFacade(IAlunoService alunoService, 
            IMateriaService materiaService, 
            IPoloService poloService, 
            IUsuarioService usuarioService, 
            IEmailService emailService)
        {
            _alunoService = alunoService;
            _materiaService = materiaService;
            _poloService = poloService;
            _usuarioService = usuarioService;
            _emailService = emailService;
        }

        public void RegistrarNovoAluno(AlunoVm alunoVm)
        {
            if (MatriculaJaExiste(alunoVm.Matricula))
                throw new Exception("Mattrícula já cadastrada");

            IEnumerable<Materia> materias = _materiaService.BuscarMateriasSelecionadas(alunoVm.MateriasSelecionadasId);
            Polo polo = _poloService.BuscarPoloSelecionado(alunoVm.PoloSelecionadoId);

            _alunoService.CriarAluno(MapearAlunoVmParaAluno(alunoVm), polo, materias);
            _usuarioService.CriarUsuarioParaAluno(alunoVm.Matricula);            
            _emailService.EnviarEmailParaAlunoCriado(alunoVm.Email);
        }

        private Aluno MapearAlunoVmParaAluno(AlunoVm alunoVm)
        {
            return new Aluno
            {
                Matricula = alunoVm.Matricula,
                Nome = alunoVm.Nome,
                Email = alunoVm.Email
            };
        }

        private bool MatriculaJaExiste(string matricula)
        {
            return _alunoService.BuscarPorMatricula(matricula) != null;
        }
    }
}
