using MediatR;

namespace MediatorPattern.Domain.Command
{
    // is the contract to be passed as request on the ProdutoCreatehandle method
    public class ProdutoCreateCommand : IRequest<string>
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
    }
}