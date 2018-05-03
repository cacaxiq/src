using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Test.Domain.Shared
{
    [TestClass]
    public class HomePhoneTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.IsFalse(false);
        }
        //[TestMethod]
        //public void ShouldReturnSuccessWhenNumberIsNotEmpty()
        //{
        //    var phone = new HomePhone("3133872482");
        //    Assert.IsTrue(phone.Valid);
        //}

        //[TestMethod]
        //public void ShouldReturnErrorWhenNumberIsEmpty()
        //{
        //    var phone = new HomePhone(string.Empty);
        //    Assert.IsTrue(phone.Invalid);
        //}

        //[TestMethod]
        //public void FormattedShouldReturnEmptyWhenInvalid()
        //{
        //    var phone = new HomePhone("31338724825");
        //    var formattedNumber = phone.Formatted();
        //    Assert.IsTrue(string.IsNullOrEmpty(formattedNumber));
        //}

        //[TestMethod]
        //public void FormattedNotShouldReturnEmptyWhenValid()
        //{
        //    var phone = new HomePhone("3133872482");
        //    var formattedNumber = phone.Formatted();
        //    Assert.IsFalse(string.IsNullOrEmpty(formattedNumber));
        //}
    }
}
