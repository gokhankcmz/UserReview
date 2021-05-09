using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PublicReview
    {
        public string content { get; set; }

        public string title { get; set; }
        public int star { get; set; }
    }
}
