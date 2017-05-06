using System;
using System.Linq;
using System.Collections.Generic;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Aluno> alunosExistentes = BuscarAlunosNaBase();
            List<Aluno> alunosImportando = BuscarAlunosDoExcel();

            IEnumerable<Aluno> alunosRepetidos = alunosImportando.Intersect(alunosExistentes);

            foreach (var alunoRepetido in alunosRepetidos)
                Console.WriteLine(alunoRepetido.Nome);
        }

        private static List<Aluno> BuscarAlunosNaBase()
        {
            return new List<Aluno> {
                new Aluno {
                    Nome = "Rafael",
                    Idade = 18,
                    Genero = "Masculino",
                    TipoCabelo = "Cacheado"           
                },
                new Aluno {
                    Nome = "Priscilla",
                    Idade = 17,
                    Genero = "Feminino",
                    TipoCabelo = "Ondulado"           
                },
                new Aluno {
                    Nome = "Marcos",
                    Idade = 17,
                    Genero = "Masculino",
                    TipoCabelo = "Cacheado"           
                },
                new Aluno {
                    Nome = "Joao",
                    Idade = 17,
                    Genero = "Masculino",
                    TipoCabelo = "Liso"           
                },
                new Aluno {
                    Nome = "Alice",
                    Idade = 21,
                    Genero = "Feminino",
                    TipoCabelo = "Liso"           
                },
                new Aluno {
                    Nome = "Ariel",
                    Idade = 16,
                    Genero = "Feminino",
                    TipoCabelo = "Ondulado"           
                }
            };
        }

        private static List<Aluno> BuscarAlunosDoExcel()
        {
            return new List<Aluno> {
                new Aluno {
                    Nome = "Rafael",
                    Idade = 18,
                    Genero = "Masculino",
                    TipoCabelo = "Cacheado"           
                },
                new Aluno {
                     Nome = "Ariel",
                    Idade = 16,
                    Genero = "Feminino",
                    TipoCabelo = "Liso"           
                },
                new Aluno {
                    Nome = "Ariel",
                    Idade = 16,
                    Genero = "Feminino",
                    TipoCabelo = "Ondulado"           
                }
            };            
        }
    }

    public class Aluno
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string TipoCabelo { get; set; }

        public override bool Equals (object obj)
        {            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var y = (Aluno)obj;
            
            if (Object.ReferenceEquals(this, y)) return true;

            return  Nome.Equals(y.Nome) && Idade.Equals(y.Idade) && Genero.Equals(y.Genero);            
        }
        
        public override int GetHashCode()
        {            
            int hashAlunoNome = Nome == null ? 0 : Nome.GetHashCode();

            int hashAlunoIdade = Idade.GetHashCode();

            return hashAlunoNome ^ hashAlunoIdade;
        }
    }
}
