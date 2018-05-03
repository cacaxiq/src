using Base.Shared.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Test.Domain.Shared
{
    [TestClass]
    public class CellPhoneTest
    {
        [TestMethod]
        public void FormattedShouldReturnEmptyWhenInvalid()
        {
            var phone = new CellPhone("3198542392");
            var formattedNumber = phone.Formatted();
            Assert.IsTrue(string.IsNullOrEmpty(formattedNumber));
        }

        [TestMethod]
        public void FormattedNotShouldReturnEmptyWhenValid()
        {
            var phone = new CellPhone("31985423925");
            var formattedNumber = phone.Formatted();
            Assert.IsFalse(string.IsNullOrEmpty(formattedNumber));
        }
    }
}
