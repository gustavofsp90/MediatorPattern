﻿using MediatorPattern.Domain.Command;
using MediatorPattern.Domain.Entity;
using MediatorPattern.Notifications;
using MediatorPattern.Repository;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace MediatorPattern.Domain.Handlers
{
    public class ProdutoDeleteCommandHandler : IRequestHandler<ProdutoDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Produto> _repository;
        public ProdutoDeleteCommandHandler(IMediator mediator, IRepository<Produto> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<string> Handle(ProdutoDeleteCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);
                await _mediator.Publish(new ProdutoDeleteNotification
                { Id = request.Id, IsConcluido = true });
                return await Task.FromResult("Produto excluido com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ProdutoDeleteNotification
                {
                    Id = request.Id,
                    IsConcluido = false
                });
                await _mediator.Publish(new ErroNotification
                {
                    Erro = ex.Message,
                    PilhaErro = ex.StackTrace
                });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}
