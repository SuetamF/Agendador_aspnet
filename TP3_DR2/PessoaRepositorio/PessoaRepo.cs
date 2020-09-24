using System;
using System.Collections.Generic;
using System.Linq;
using TP3_DR2.Models;
using System.Threading.Tasks;


namespace TP3_DR2.PessoaRepositorio
{
    public class PessoaRepo
    {
        private static int contaId = 1;

        public static int AddId()
        {
            contaId = contaId + 1;
            return contaId;
        }

        public static int GetId()
        {
            return contaId;
        }

        private static List<Pessoa> pessoaList = new List<Pessoa>
        {
            new Pessoa(){ IDPessoa = 0, Nome = "Mateus", Sobrenome = "Fonseca", Aniversario = new DateTime(1999,11,16) }
        };

        public static void AddPessoa(Pessoa pessoa)
        {
            pessoaList.Add(pessoa);
        }

        public static List<Pessoa> GetpessoaList()
        {
            return pessoaList;
        }

        public static Pessoa BuscarID(int id)
        {
            Pessoa resultado = new Pessoa();
            foreach (Pessoa p in pessoaList)
            {
                if (p.IDPessoa == id)
                {
                    resultado.IDPessoa = p.IDPessoa;
                    resultado.Nome = p.Nome;
                    resultado.Sobrenome = p.Sobrenome;
                    resultado.Aniversario = p.Aniversario;
                    break;
                }
            }
            return resultado;
        }

        public static void Editpessoa(int id, Pessoa pessoaUpdate)
        {
            foreach (Pessoa p in pessoaList)
            {
                if (p.IDPessoa == id)
                {
                    p.Nome = pessoaUpdate.Nome;
                    p.Sobrenome = pessoaUpdate.Sobrenome;
                    p.Aniversario = pessoaUpdate.Aniversario;
                    break;
                }
            }

        }

        public static void DeletePessoa(int id)
        {
            foreach (Pessoa p in pessoaList)
            {
                if (p.IDPessoa == id)
                {
                    pessoaList.Remove(p);
                    break;
                }
            }
        }

        public static List<Pessoa> BuscarPessoa(string pesquisa)
        {
            List<Pessoa> resultados = new List<Pessoa>();
            foreach (Pessoa p in pessoaList)
            {
                if (p.Nome.Contains(pesquisa))
                {
                    resultados.Add(p);
                }
            }
            return resultados;
        }

        public static void Create(Pessoa pessoa)
        {
            
            
            pessoa.IDPessoa = GetId();
            AddPessoa(pessoa);
            AddId();

        }

    }
}
