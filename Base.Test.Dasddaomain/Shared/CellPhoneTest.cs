using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Test.Domain.Shared
{
    [TestClass]
    public class CellPhoneTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.IsFalse(false);
        }
        //[TestMethod]
        //public void ShouldReturnSuccessWhenNumberIsNotEmpty()
        //{
        //    var phone = new CellPhone("31985423925");
        //    Assert.IsTrue(phone.Valid);
        //}

        //[TestMethod]
        //public void ShouldReturnErrorWhenNumberIsEmpty()
        //{
        //    var phone = new CellPhone(string.Empty);
        //    Assert.IsTrue(phone.Invalid);
        //}

        //[TestMethod]
        //public void FormattedShouldReturnEmptyWhenInvalid()
        //{
        //    var phone = new CellPhone("3198542392");
        //    var formattedNumber = phone.Formatted();
        //    Assert.IsTrue(string.IsNullOrEmpty(formattedNumber));
        //}

        //[TestMethod]
        //public void FormattedNotShouldReturnEmptyWhenValid()
        //{
        //    var phone = new CellPhone("31985423925");
        //    var formattedNumber = phone.Formatted();
        //    Assert.IsFalse(string.IsNullOrEmpty(formattedNumber));
        //}
    }
}
