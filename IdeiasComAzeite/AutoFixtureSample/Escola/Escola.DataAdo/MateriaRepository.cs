using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.Model;

namespace Escola.DataAdo
{
    public class MateriaRepository : IMateriaRepo
    {
        public Materia BuscarMateriaPorNome(string nomeMateria)
        {
            //Buscar materia no banco de dados
            return null;
        }

        public IEnumerable<Materia> BuscarMaterias()
        {
            return new List<Materia>
            {
                new Materia
                {
                    Nome = "Física"
                },
                new Materia
                {
                    Nome = "Química"
                },
                new Materia
                {
                    Nome = "Matemática"
                }
            };
        }

        public IEnumerable<Materia> BuscarMateriasSelecionadas(IEnumerable<int> materiasSelecionadasId)
        {
            //Buscar materias no banco de dados
            return null;
        }

        public void CadastrarMateria(Materia materia)
        {
            //Cadastrar materia no banco de dados
        }
    }
}
