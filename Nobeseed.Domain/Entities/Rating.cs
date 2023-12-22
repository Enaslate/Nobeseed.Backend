using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobeseed.Domain.Entities
{
    public class Rating
    {
        [Key]
        public Guid Id { get; }
        public Guid BookId { get; }
        public int Stars { get; private set; }
    }
}
