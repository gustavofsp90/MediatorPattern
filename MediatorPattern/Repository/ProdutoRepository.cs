using MediatorPattern.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private Dictionary<int, Produto> produtos = new Dictionary<int, Produto>();

        public Dictionary<int, Produto> GetProdutos()
        {
            produtos.Add(1, new Produto { Id = 1, Nome = "Caneta", Preco = 3.45m });
            produtos.Add(2, new Produto { Id = 2, Nome = "Caderno", Preco = 7.65m });
            produtos.Add(3, new Produto { Id = 3, Nome = "Borracha", Preco = 1.20m });
            return produtos;
        }
        public ProdutoRepository() 
        { 
            produtos = GetProdutos();
        }
        
        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await Task.Run(() => produtos.Values.ToList());
        }
        public async Task<Produto> Get(int id)
        {
            return await Task.Run(() => produtos.GetValueOrDefault(id));
        }
        public async Task Add(Produto produto)
        {
            await Task.Run(() => produtos.Add(produto.Id, produto));
        }
        public async Task Edit(Produto produto)
        {
            await Task.Run(() =>
            {
                produtos.Remove(produto.Id);
                produtos.Add(produto.Id, produto);
            });
        }
        public async Task Delete(int id)
        {
            await Task.Run(() => produtos.Remove(id));
        }
    }
}
