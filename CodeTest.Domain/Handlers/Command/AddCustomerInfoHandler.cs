using System;
using System.Threading;
using System.Threading.Tasks;
using CodeTest.Domain.Commands;
using CodeTest.Domain.Contract.Request;
using CodeTest.Domain.Contract.Response;
using CodeTest.Domain.Repository.Interface;
using MediatR;

namespace CodeTest.Domain.Handlers.Command
{
	
    public class AddCustomerInfoHandler : IRequestHandler<AddCustomerInfoCommand, AddCustomerInfoResponse>
    {
        private ICustomerRepository _customerRepository;

        public AddCustomerInfoHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<AddCustomerInfoResponse> Handle(AddCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            AddCustomerInfoResponse response = null;
            try
            {
                var customer = await _customerRepository.AddCustomerDetails(request);
                if (customer != null)
                {

                    response = new AddCustomerInfoResponse
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

