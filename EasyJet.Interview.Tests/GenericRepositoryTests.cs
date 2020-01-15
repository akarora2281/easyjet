using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EasyJet.Interview.Tests
{
    [TestFixture]
    public class GenericRepositoryTests
    {
        private object expectedResult;

        public GenericRepository<TestEmployee, int> Repository { get; private set; }

        private TestEmployee employee1, employee2;

        [SetUp]
        public void Setup()
        {
            Repository = new GenericRepository<TestEmployee, int>();
            employee1 = new TestEmployee { Id = 1, EmployeeName = "Emp1" };
            employee2 = new TestEmployee { Id = 2, EmployeeName = "Emp2" };
        }

        [Test]
        public void Should_Returns_List_Of_Items_When_GetAll_Method_Called()
        {
            Assert.IsTrue(expectedResult.GetType() == typeof(List<TestEmployee>));
        }

        [Test]
        public void Should_Save_NewItem_When_AddNewItem_Called_With_Valid_ItemData()
        {
            Repository.Save(employee1);
            expectedResult = Repository.GetAll();

            Assert.IsTrue(((IEnumerable<TestEmployee>)expectedResult).Contains(employee1));
        }

        [Test]
        public void Should_Return_Item_WhenItem_Id_Provided()
        {
            Repository.Save(employee1);
            Repository.Save(employee2);

            Assert.AreEqual(employee1, Repository.Get(1));
            Assert.AreEqual(employee2, Repository.Get(2));
        }

        [Test]
        public void Should_Delete_Item_From_Repository_When_Delete_Method_Called_With_ItemId()
        {
            Repository.Save(employee1);
            Repository.Save(employee2);

            Repository.Delete(1);

            expectedResult = Repository.GetAll();

            Assert.IsFalse(((IEnumerable<TestEmployee>)expectedResult).Contains(employee1));
        }
    }
}