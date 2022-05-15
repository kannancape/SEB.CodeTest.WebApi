using System.Threading.Tasks;
using CodeTest.Domain.Entities;
using CodeTest.Domain.Repository.Interface;

namespace CodeTest.Domain.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        Task<CustomerDetails> ICustomerRepository.GetCustomerDetails(string id)
        {
            //throw new System.NotImplementedException();
            return Task.FromResult<CustomerDetails>(null);
        }
    }
}

