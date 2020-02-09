using MediatorPatternExample.Domain.Customer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatorPatternExample.Infra
{


    //ICustomerRepository é onde ficam os contratos(repositório) de acesso a dados.Notem que utilizei acesso a dados,
    //portanto, não necessariamente precisa ser utilizado um banco de dados, e a classe CustomerRepository contém as
    //implementações desses contratos.
    public interface ICustomerRepository
    {
        Task Save(CustomerEntity customer);
        Task Update(int id, CustomerEntity customer);
        Task Delete(int id);
        Task<CustomerEntity> GetById(int id);
        Task<IEnumerable<CustomerEntity>> GetAll();
    }
}
