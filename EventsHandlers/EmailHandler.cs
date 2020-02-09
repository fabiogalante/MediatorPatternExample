using MediatorPatternExample.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPatternExample.EventsHandlers
{


    //EmailEvent é a classe responsável por receber a notificação do registro de um novo cliente e executar o fluxo de envio do e-mail.

    //Nessa classe, herdamos da interface INotificationHandler, disponibilizada também pelo MediatR, que nos obriga a
    //implementar o método Handle, responsável por receber a notificação e executar a lógica de envio do e-mail.

    //Nesse caso, exibiremos apenas uma mensagem de console para facilitar o entendimento.

    //Portanto, sempre que emitimos alguma notificação referente a cliente em nosso sistema, nossa classe
    //EmailHandler é responsável por receber essa notificação e processá-la.
    public class EmailHandler : INotificationHandler<CustomerActionNotification>
    {
        public Task Handle(CustomerActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("O cliente {0} {1} foi {2} com sucesso", notification.FirstName, notification.LastName, notification.Action.ToString().ToLower());
            });
        }
    }
}
