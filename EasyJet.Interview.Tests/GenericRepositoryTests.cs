using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EasyJet.Interview.Tests
{
    [TestFixture]
    public class GenericRepositoryTests
    {
        private object expectedResult;

        public GenericRepository<TestEmployee, int> _repository { get; private set; }

        private TestEmployee employee1, employee2;

        [SetUp]
        public void Setup()
        {
            _repository = new GenericRepository<TestEmployee, int>();
            employee1 = new TestEmployee { Id = 1, EmployeeName = "Emp1" };
            employee2 = new TestEmployee { Id = 2, EmployeeName = "Emp2" };
        }

        [Test]
        public void Should_Returns_IEnumberable_When_GetAll_Method_Called()
        {
            expectedResult = _repository.GetAll();

            Assert.NotNull(expectedResult);
        }

        [Test]
        public void Should_Save_NewItem_When_AddNewItem_Called_With_Valid_ItemData()
        {
            _repository.Save(employee1);
            expectedResult = _repository.GetAll();

            Assert.IsTrue(((IEnumerable<TestEmployee>)expectedResult).Contains(employee1));
        }

        [Test]
        public void Should_Return_Item_WhenItem_Id_Provided()
        {
            _repository.Save(employee1);
            _repository.Save(employee2);

            Assert.AreEqual(employee1, _repository.Get(1));
            Assert.AreEqual(employee2, _repository.Get(2));
        }

        [Test]
        public void Should_Delete_Item_From_Repository_When_Delete_Mthod_Called_With_ItemId()
        {
            _repository.Save(employee1);
            _repository.Save(employee2);

            _repository.Delete(1);

            expectedResult = _repository.GetAll();

            Assert.IsFalse(((IEnumerable<TestEmployee>)expectedResult).Contains(employee1));
        }
    }
}