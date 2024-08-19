using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Data;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Services;

public class ServiceBusca
{
    private readonly WebApplicationMvcContext _context;

    public ServiceBusca(WebApplicationMvcContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> PesquisarProdutosPorNomeAsync(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            return await _context.Produto.ToListAsync();
        }

        return await _context.Produto
            .Where(p => p.Nome.Contains(nome))
            .ToListAsync();
    }

}
