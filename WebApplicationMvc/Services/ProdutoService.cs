using WebApplicationMvc.Data;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Services;

public class ProdutoService
{
    private readonly WebApplicationMvcContext _context;

    public ProdutoService(WebApplicationMvcContext context)
    {
        _context = context;
    }
    public List<Produto> TodosProdutos()
    {
        return _context.Produto.ToList();
    }
}
