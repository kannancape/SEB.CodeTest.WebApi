using System;
using System.ComponentModel.DataAnnotations;

namespace CodeTest.Domain.Entities
{
	public class CustomerDetails 
	{
		public Guid Id { get; set; }
		[Required]
		public string SocialNumber { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
	}
}

