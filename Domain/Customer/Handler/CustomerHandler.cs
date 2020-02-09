using MediatorPatternExample.Domain.Customer.Command;
using MediatorPatternExample.Domain.Customer.Entity;
using MediatorPatternExample.Infra;
using MediatorPatternExample.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPatternExample.Domain.Customer.Handler
{


    //CustomerHandler tem a responsabilidade de coordenar as ações necessária para persistir a entidade no
    //banco de dados, ou seja, é aqui onde fica a implementação do fluxo de dados, validações, entre outros.





    //Note que possuímos uma herança do IRequestHandler que nos obriga a implementar o método Handler,
    //responsável por receber os commands e orquestrar
    //todo o fluxo de validação e regras de negócio da nossa entidade CustomerEntity.

    // Nessa classe possuímos três métodos Handlers, mas cada método representa uma ação
    // diferente, já que recebemos commands diferentes nos parâmetros.

    //Outro ponto importante é sobre o método Publish(), responsável por emitir a
    //notificação em todo sistema, onde ele vai procurar a classe que possui a herança da interface INotificationHandler<tipo do objeto> e invocar o método Handler() para processar aquela notificação.

    //    Vale ressaltar que apenas invocará a classe responsável por um determinado tipo de informação.Ou seja, se a
    // notificação é relacionada a um cliente, apenas notificações de cliente ela processará.


    public class CustomerHandler :
        IRequestHandler<CustomerCreateCommand, string>,
        IRequestHandler<CustomerUpdateCommand, string>,
        IRequestHandler<CustomerDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.Id, request.FirstName, request.LastName, request.Email,
                request.Phone);
            await _customerRepository.Save(customer);

            await _mediator.Publish(new CustomerActionNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Criado
            }, cancellationToken);

            return await Task.FromResult("Cliente registrado com sucesso");
        }

        public async Task<string> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.Id, request.FirstName, request.LastName, request.Email,
                request.Phone);
            await _customerRepository.Update(request.Id, customer);

            await _mediator.Publish(new CustomerActionNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Atualizado
            }, cancellationToken);

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var client = await _customerRepository.GetById(request.Id);
            await _customerRepository.Delete(request.Id);

            await _mediator.Publish(new CustomerActionNotification
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Action = ActionNotification.Excluido
            }, cancellationToken);

            return await Task.FromResult("Cliente excluido com sucesso");
        }
    }
}

