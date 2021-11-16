using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.ViewModels
{
    public class UserViewModel
	{ 
		public int Id { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Sex { get; set; }
		public List<string> Bookmarks { get; set; }
		public List<string> SearchHistory { get; set; }
		public List<string> UserRatings { get; set; }
	}
}
