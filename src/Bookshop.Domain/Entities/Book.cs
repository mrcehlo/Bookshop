using Bookshop.Domain.Entities.Base;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Domain.Entities
{
    public class Book : EntityBase
    {
        // Reinstate ID property to avoid further mapping errors from MongoDB
        public Guid Id
        {
            get { return DefaultId; }
            set { DefaultId = value; }
        }
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Publisher { get; private set; }
        public decimal Price { get; private set; }
        public string BookShelfLocalization { get; private set; }
        public int Quantity { get; private set; }

        public Book(string _ISBN,
            string _Title,
            string _Author,
            string _Publisher,
            decimal _Price,
            string _BookShelfLocalization,
            int _Quantity)
        {
            ISBN = _ISBN;
            Title = _Title;
            Author = _Author;
            Publisher = _Publisher;
            Price = _Price;
            BookShelfLocalization = _BookShelfLocalization;
            Quantity = _Quantity;

            var vMandatoryInfoText = "is a mandatory field.";

            AddNotifications(new Contract()
               .Requires()
               .IsNotNullOrEmpty(ISBN, "ISBN", $"ISBN {vMandatoryInfoText}")
               .IsNotNullOrEmpty(Title, "Title", $"Title {vMandatoryInfoText}")
               .IsNotNullOrEmpty(Author, "Author", $"Author {vMandatoryInfoText}")
               .IsNotNullOrEmpty(Publisher, "Publisher", $"Publisher {vMandatoryInfoText}")
               .IsGreaterThan(Price, 0, "Price", "Price should be a valid value.")
               .IsNotNullOrEmpty(BookShelfLocalization, "BookShelfLocalization", $"BookShelfLocalization {vMandatoryInfoText}")
               .IsGreaterOrEqualsThan(Quantity, 0, "Quantity", "Quantity should be a positive number."));
        }
    }
}
