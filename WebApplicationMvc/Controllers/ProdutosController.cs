using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly WebApplicationMvcContext _context;

        public ProdutosController(WebApplicationMvcContext context)
        {
            _context = context;
        }

       public IActionResult Index()
        {
            return View();
        }
    }
}
