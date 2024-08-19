using Microsoft.EntityFrameworkCore;
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
    public void Atualizar(Produto obj)
    {
        if(!_context.Produto.Any(x => x.Id == obj.Id))
        {
            throw new Exception();
        }
        try
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException e)
        {

            throw new Exception(e.Message);
        }
    }
}
