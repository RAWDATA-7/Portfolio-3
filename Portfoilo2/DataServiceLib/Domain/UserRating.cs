using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    class UserRating
    {
        public int UserID { get; set; }
        public string TitleID { get; set; }
        public decimal Rating { get; set; }

        public User User { get; set; }
        public Rating TitleRating { get; set; }

        public override string ToString()
        {
            return $"UserID = {UserID}, TitleID = {TitleID}, Rating = {Rating}, User = {User}, TitleRating = {TitleRating}";
        }
    }
}
