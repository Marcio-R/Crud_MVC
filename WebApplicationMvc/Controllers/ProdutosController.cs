using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;
using WebApplicationMvc.Services;

namespace WebApplicationMvc.Controllers
{

    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = await _produtoService.TodosProdutos();
            return View(list);
        }
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Master")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            await _produtoService.InseriProduto(produto);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = await _produtoService.BuscaId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = await _produtoService.BuscaId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _produtoService.BuscaId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }
            if (id != produto.Id)
            {
                return BadRequest();
            }
            try
            {
                await _produtoService.Atualizar(produto);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
