using System;
using System.Collections.Generic;

namespace DataServiceLib.Domain
{
	public class User
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Sex { get; set; }
		public Byte[] Password { get; set; }
		public Byte[] Salt { get; set; }
		
		public ICollection<SearchHistory> SearchHistory { get; set; }
		public ICollection<UserRating> UserRatings { get; set; }
		public ICollection<Bookmark> Bookmarks { get; set; }

		public override string ToString()
		{
			return $"Id = {Id}, Name = {Name}, FirstName = {FirstName}, LastName = {LastName}, Email = {Email}, Sex = {Sex}," +
				$" Password = {Password}, Salt = {Salt}, SearchHistories = {SearchHistory}, UserRatings = {UserRatings}, Bookmarks = {Bookmarks}";
		}
	}
}
