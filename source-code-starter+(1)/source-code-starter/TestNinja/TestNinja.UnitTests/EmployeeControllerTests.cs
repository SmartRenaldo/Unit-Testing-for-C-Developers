using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var employeeService = new Mock<IEmployeeService>();
            var controller = new EmployeeController(employeeService.Object);

            controller.DeleteEmployee(1);

            employeeService.Verify(s => s.DeleteEmployee(1));
        }

    }
}
