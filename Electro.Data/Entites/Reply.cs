using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Data.Entites
{
    public class Reply
    {
        public int  Id { get; set; }
        public string Text {  get; set; }

        [ForeignKey("Review")]
        public int ReviewId {  get; set; }
        public Review Review { get; set; }
    }
}
