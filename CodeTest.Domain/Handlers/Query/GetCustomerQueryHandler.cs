using System;
using System.Threading;
using System.Threading.Tasks;
using CodeTest.Domain.Contract.Response;
using CodeTest.Domain.Queries;
using CodeTest.Domain.Repository.Interface;
using MediatR;

namespace CodeTest.Domain.Handlers.Query
{
	public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerResponse>
	{
        private ICustomerRepository _customerRepository; 

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository; 
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            GetCustomerResponse response = null;
            try
            {
                var customer = await _customerRepository.GetCustomerDetails(request.CustomerRequest);
                if (customer != null)
                {
                    
                    response = new GetCustomerResponse
                    {
                        SocialNumber = customer.SocialNumber,
                        EmailAddress = customer.EmailAddress,
                        PhoneNumber = customer.PhoneNumber
                    }; 
                } 
                return response;
            }
            catch (Exception)
            {
                return response;
            }
        }

      
    }

 
}

