﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class User
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Sex { get; set; }
		public string Password { get; set; }

		public ICollection<SearchHistory> SearchHistories { get; set; }
		public ICollection<UserRating> UserRatings { get; set; }

		public ICollection<Bookmark> Bookmarks { get; set; }

		public override string ToString()
		{
			return $"Id = {Id}, Name = {Name}, FirstName = {FirstName}, LastName = {LastName}, Email = {Email}, Sex = {Sex}," +
				$" Password = {Password}, SearchHistories = {SearchHistories}, UserRatings = {UserRatings}, Bookmarks = {Bookmarks}";
		}
	}
}