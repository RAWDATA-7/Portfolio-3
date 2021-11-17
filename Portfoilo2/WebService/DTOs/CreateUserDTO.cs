using System;

namespace WebService.DTOs
{
    public class CreateUserDTO
    {
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Sex { get; set; }
		public string PlainTxtPwd { get; set; }
		public Byte[] Password { get; set; }
		public Byte[] Salt { get; set; }
	}
}
