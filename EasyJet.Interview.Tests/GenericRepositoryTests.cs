using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EasyJet.Interview.Tests
{
    public class GenericRepositoryTests
    {
        private object expectedResult;

        public GenericRepository<TestEmployee, int> _repository { get; private set; }

        [Test]
        public void Should_Returns_IEnumberable_When_GetAll_Method_Called()
        {
            //Arrange
            _repository = new GenericRepository<TestEmployee, int>();

            // Act
            expectedResult = _repository.GetAll();

            //Assert
            Assert.NotNull(expectedResult);
        }

        [Test]
        public void Should_Save_NewItem_When_AddNewItem_Called_With_Valid_ItemData()
        {
            //Arrange
            _repository = new GenericRepository<TestEmployee, int>();
            var newEmployee = new TestEmployee { Id = 1, EmployeeName = "Emp1" };

            // Act
            _repository.Save(newEmployee);
            expectedResult = _repository.GetAll();

            //Assert
            Assert.IsTrue(((IEnumerable<TestEmployee>)expectedResult).Contains(newEmployee));
        }
    }
}