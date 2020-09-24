using System;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using TP3_DR2.Models;
using TP3_DR2.PessoaRepositorio;
using TP3_DR2.ViewModels;


namespace TP3_DR2.Controllers
{
    public class PessoaController : Controller
    {

        #region All
        public ActionResult Index()
        {
            

            IEnumerable<Pessoa> pessoas = PessoaRepo.GetpessoaList();

            IEnumerable<PessoaViewModel> pessoasviewmodel = pessoas.Select(x => new PessoaViewModel
            {
                IDPessoa = x.IDPessoa,
                Nome = x.Nome,
                Sobrenome = x.Sobrenome,
                Aniversario = x.Aniversario
            });
            return View(pessoasviewmodel);
        }
        #endregion

        #region Create
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {

            PessoaRepo.Create(pessoa);

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = PessoaRepo.BuscarID(id);
            PessoaViewModel pessoaviewmodel = new PessoaViewModel
            {
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Aniversario = pessoa.Aniversario

            };
            return View(pessoaviewmodel);
        }
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = collection["Nome"];
                pessoa.Sobrenome = collection["Sobrenome"];
                pessoa.Aniversario = DateTime.Parse(collection["Aniversario"]);

                PessoaRepo.Editpessoa(id, pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {

            Pessoa pessoa = PessoaRepo.BuscarID(id);
            PessoaViewModel pessoaviewmodel = new PessoaViewModel
            {
                IDPessoa = pessoa.IDPessoa,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Aniversario = pessoa.Aniversario

            };
            return View(pessoaviewmodel);
        }
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                PessoaRepo.DeletePessoa(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Details
        public ActionResult Details(int id)
        {

            Pessoa pessoa = PessoaRepo.BuscarID(id);
            PessoaViewModel pessoaviewmodel = new PessoaViewModel
            {
                IDPessoa = pessoa.IDPessoa,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Aniversario = pessoa.Aniversario

            };
            return View(pessoaviewmodel);
        }
        #endregion

        #region Search
        public ActionResult Search(string pesquisa)
        {
            IEnumerable<Pessoa> pessoas = PessoaRepo.BuscarPessoa(pesquisa);
            IEnumerable<PessoaViewModel> pessoasviewmodel = pessoas.Select(x => new PessoaViewModel
            {
                IDPessoa = x.IDPessoa,
                Nome = x.Nome,
                Sobrenome = x.Sobrenome,
                Aniversario = x.Aniversario


            });
            return View(pessoasviewmodel);
        }

        
        #endregion
    }
}
