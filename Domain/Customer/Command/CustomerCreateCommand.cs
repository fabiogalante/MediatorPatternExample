using MediatR;

namespace MediatorPatternExample.Domain.Customer.Command
{

    //As classes CustomerCreateCommand, CustomerDeleteCommand e CustomerUpdateCommand são DTOs (Data Transfer Object) que representam a ação
    //que a aplicação deve realizar ao utilizar esse objeto.




    //Em todos os nossos commands, é herdada o IRequest, que é uma interface disponibilizada pelo mediatR, utilizada para
    //indicar que esse é um comando utilizado por nossas classes Handlers, que vamos ver um pouco mais a frente.

    // Esses commands acima representam algum tipo de ação que deve ser executado(Create, Update e Delete).
    public class CustomerCreateCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
