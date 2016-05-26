using Escola.Domain.Interfaces;
using Escola.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Escola.Api.Controllers
{
    public class AlunoController : ApiController
    {
        private IAlunoFacade _alunoFacade;

        public AlunoController(IAlunoFacade alunoFacade)
        {
            _alunoFacade = alunoFacade;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]AlunoVm alunoVm)
        {
            try
            {
                _alunoFacade.RegistrarNovoAluno(alunoVm);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        
    }
}
