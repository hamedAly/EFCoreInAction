using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public int NewPrice { get; set; }
        public string TextPromotion { get; set; }
        public int BooKId { get; set; }
    }
}
