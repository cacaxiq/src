using Base.Shared.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Test.Domain.Shared
{
    [TestClass]
    public class HomePhoneTest
    {
        [TestMethod]
        public void FormattedShouldReturnEmptyWhenInvalid()
        {
            var phone = new HomePhone("31338724825");
            var formattedNumber = phone.Formatted();
            Assert.IsTrue(string.IsNullOrEmpty(formattedNumber));
        }

        [TestMethod]
        public void FormattedNotShouldReturnEmptyWhenValid()
        {
            var phone = new HomePhone("3133872482");
            var formattedNumber = phone.Formatted();
            Assert.IsFalse(string.IsNullOrEmpty(formattedNumber));
        }
    }
}
