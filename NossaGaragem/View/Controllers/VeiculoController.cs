using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class VeiculoController : Controller
    {
        private VeiculoRepository repository;
        // GET: Veiculo

        public VeiculoController()
        {
            repository = new VeiculoRepository();
        }


        public ActionResult Index()
        {
            List<Veiculo> lista = repository.ObterTodos();
            ViewBag.Veiculos = lista;
            return View();
        }
        
        public ActionResult Cadastro()
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> lista = categoriaRepository.ObterTodos();
            ViewBag.Categorias = lista;
            return View();
        }

        public ActionResult Store(string modelo, int categoria, decimal valor)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.Modelo = modelo;
            veiculo.IdCategoria = categoria;
            veiculo.Valor = valor;
            repository.Inserir(veiculo);
            return RedirectToAction("Index");
        }
        
        public ActionResult Apagar(int id)
        {
            repository.Deletar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Atualizar(int id)
        {
            Veiculo veiculo = repository.ObterPeloId(id);
            @ViewBag.Veiculo = veiculo;

            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> lista = categoriaRepository.ObterTodos();
            @ViewBag.Categoria = lista;
            return View();
        }

        public ActionResult Update(int id, string modelo, decimal valor, int categoria)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.Id = id;
            veiculo.Modelo = modelo;
            veiculo.Valor = valor;
            veiculo.Categoria = new Categoria();
            veiculo.Categoria.Id = categoria;
            repository.Atualizar(veiculo);
            return RedirectToAction("Index");
        }
    }
}