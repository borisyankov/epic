using System;

namespace Epic.Domain
{
	public class Account
	{
		public string Email { get; set; }
		public string HashedPassword { get; set; }

		public DateTime SignupDate { get; set; }

		public Person Person { get; set; }
	}
}
