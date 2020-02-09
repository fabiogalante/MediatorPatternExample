namespace MediatorPatternExample.Domain.Customer.Entity
{

    //CustomerEntity representa a nossa entidade de domínio Cliente, portanto ela possui estado,
    //comportamento e suas regras de negócio.
    public class CustomerEntity
    {
        public CustomerEntity(int id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public int Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
    }
}
