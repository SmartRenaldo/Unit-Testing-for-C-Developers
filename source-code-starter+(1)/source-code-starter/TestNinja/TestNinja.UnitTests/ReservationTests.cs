using System;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = true });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_SameUserWhoBookedTheReservation_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();
            var s = new User() { IsAdmin = false };
            reservation.MadeBy = s;

            // Act
            var result = reservation.CanBeCancelledBy(s);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            // Arrange
            var reservation = new Reservation() { MadeBy = new User () };

            // Act
            var result = reservation.CanBeCancelledBy(new User() { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }
    }
}
