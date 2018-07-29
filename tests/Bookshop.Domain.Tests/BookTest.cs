using Bookshop.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bookshop.Domain.Tests
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        [TestCategory("Book - Add Book")]
        public void GivenAnEmptyISBNShouldReturnANotification()
        {
            var book = new Book(string.Empty, "title", "author", "publihser", 10, "localization", 5);
            Assert.IsFalse(book.Valid);
        }

        [TestMethod]
        [TestCategory("Book - Add Book")]
        public void GivenAnEmptyTitlehouldReturnANotification()
        {
            var book = new Book("ISBN", string.Empty, "author", "publihser", 10, "localization", 5);
            Assert.IsFalse(book.Valid);
        }

        [TestMethod]
        [TestCategory("Book - Add Book")]
        public void GivenAnEmptyAuthorShouldReturnANotification()
        {
            var book = new Book("ISBN", "title", string.Empty, "publihser", 10, "localization", 5);
            Assert.IsFalse(book.Valid);
        }

        [TestMethod]
        [TestCategory("Book - Add Book")]
        public void GivenAnEmptyPublisherShouldReturnANotification()
        {
            var book = new Book("ISBN", "title", "author", string.Empty, 10, "localization", 5);
            Assert.IsFalse(book.Valid);
        }

        [TestMethod]
        [TestCategory("Book - Add Book")]
        public void GivenAnEmptyLocalizationShouldReturnANotification()
        {
            var book = new Book("ISBN", "title", "author", "publisher", 10, string.Empty, 5);
            Assert.IsFalse(book.Valid);
        }

        [TestMethod]
        [TestCategory("Book - Add Book")]
        public void GivenANegativeQuantityShouldReturnANotification()
        {
            var book = new Book("ISBN", "title", "author", "publisher", 10, "localization", -1);
            Assert.IsFalse(book.Valid);
        }

        [TestMethod]
        [TestCategory("Book - Add Book")]
        public void GivenAPriceNotGreaterThanZeroShouldReturnANotification()
        {
            var book = new Book("ISBN", "title", "author", "publisher", 0,"localization", 5);
            Assert.IsFalse(book.Valid);
        }
    }
}
