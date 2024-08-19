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

    public void InseriProduto(Produto produto)
    {
        _context.Add(produto);
        _context.SaveChanges();
    }

    public Produto BuscaId(int id)
    {
        return _context.Produto.FirstOrDefault(obj => obj.Id == id);
    }
    public void Remove (int id)
    {
        var obj = _context.Produto.Find(id);
        _context.Produto.Remove(obj);
        _context.SaveChanges();
    }
}
