using CodeTest.Domain.Contract.Request;
using CodeTest.Domain.Contract.Response;
using MediatR;

namespace CodeTest.Domain.Queries
{
    public class GetCustomerQuery : IRequest<GetCustomerResponse>
    {
        public string CustomerRequest { get; set; }
        public GetCustomerQuery(string customerRequest)
        {
            CustomerRequest = customerRequest;
        }
    }
}
