using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.Domain.Entities
{
    public partial class Topic
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public HashSet<Vocab> Vocabs { get; set; }

        public DateTime Created { get; set; }

        public Topic()
        {
            Vocabs = new HashSet<Vocab>();
        }
    }
}
