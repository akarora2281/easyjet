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
            _repository = new GenericRepository<TestEmployee, int>();
            expectedResult = _repository.GetAll();

            Assert.NotNull(expectedResult);
        }
    }
}