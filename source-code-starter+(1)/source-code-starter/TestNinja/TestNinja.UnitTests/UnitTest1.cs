using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_MadeByUser_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var s = new User() { IsAdmin = false };
            reservation.MadeBy = s;
            var result = reservation.CanBeCancelledBy(s);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsNotAdminAndNotMadeByUser_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var s = new User() { IsAdmin = false };
            reservation.MadeBy = s;
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }
    }
}
