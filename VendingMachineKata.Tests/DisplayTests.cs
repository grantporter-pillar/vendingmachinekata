using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class DisplayTests
    {
        [TestMethod]
        public void WhenTheMachineIsReadyToAcceptMoney_TheDisplayReadsInsertCoin()
        {
            Equals(VendingMachine.GetDisplay(), @"INSERT COIN");
        }
    }
}
