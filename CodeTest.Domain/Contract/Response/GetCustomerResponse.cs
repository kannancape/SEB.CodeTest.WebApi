using System;

namespace CodeTest.Domain.Contract.Response
{
	public class GetCustomerResponse
    {
        public Guid Id { get; set; } 
        public string SocialNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

    }
}
 

