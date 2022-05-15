using System;
using CodeTest.Domain.Contract;
using CodeTest.Domain.Contract.Request;
using CodeTest.Domain.Contract.Response;
using MediatR;

namespace CodeTest.Domain.Commands
{
	public class AddCustomerInfoCommand : IRequest<AddCustomerInfoResponse>
    {
		public AddCustomerInfoCommand(AddCustomerInfoRequest infoRequest)
        {
            InfoRequest = infoRequest;
        }
        public AddCustomerInfoRequest InfoRequest { get; set; }
    }
}


