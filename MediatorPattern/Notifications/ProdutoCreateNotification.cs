using MediatR;

namespace MediatorPattern.Notifications
{
    public class ProdutoCreateNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
