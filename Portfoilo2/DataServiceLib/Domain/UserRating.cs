using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Domain
{
    public class UserRating
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public decimal Rating { get; set; }

        public override string ToString()
        {
            return $"UserId = {UserId}, TitleId = {TitleId}, Rating = {Rating}";
        }
    }
}
