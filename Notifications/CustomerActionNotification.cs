using MediatR;

namespace MediatorPatternExample.Notifications
{


    //CustomerActionEvent representa um DTO (Data Transfer Object) que contém informações sobre o registro
    //persistido na base de dados, portanto, quando uma ação de persistência é executada com sucesso, esse objeto é
    //preenchido e passado para as classes que estão esperando por esse objeto.
    public class CustomerActionNotification : INotification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ActionNotification Action { get; set; }
    }
}
