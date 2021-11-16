using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class CreateUserDTO
    {
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Sex { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
	}
}
