using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshop.Service.WebAPI.ViewModels
{
    public class BookViewModel
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public string BookShelfLocalization { get; set; }
        public int Quantity { get; set; }
    }
}
