using Escola.DataAdo;
using Escola.Domain;
using Escola.Domain.Interfaces;
using Escola.Domain.Model;
using Escola.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Escola.Api.Controllers
{
    public class MateriaController : ApiController
    {
        private IMateriaService _materiaService;

        public MateriaController()
        {
            var materiaRepo = new MateriaRepository();
            _materiaService = new MateriaService(materiaRepo);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Materia materia)
        {
            try
            {
                _materiaService.CriarNovaMateria(materia);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        
    }
}
