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
    public async Task<List<Produto>> TodosProdutos()
    {
        return await _context.Produto.ToListAsync();
    }

    public async Task InseriProduto(Produto produto)
    {
        _context.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task<Produto> BuscaId(int id)
    {
        return await _context.Produto.FirstOrDefaultAsync(obj => obj.Id == id);
    }
    public async Task Remove(int id)
    {
        var obj = _context.Produto.Find(id);
        _context.Produto.Remove(obj);
        await _context.SaveChangesAsync();
    }
    public async Task Atualizar(Produto obj)
    {
        bool existe = await _context.Produto.AnyAsync(x => x.Id == obj.Id);
        if (!existe)
        {
            throw new Exception();
        }
        try
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {

            throw new Exception(e.Message);
        }
    }
   
}
