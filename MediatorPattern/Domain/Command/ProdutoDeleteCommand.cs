using MediatR;

namespace MediatorPattern.Domain.Command
{
    public class ProdutoDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
