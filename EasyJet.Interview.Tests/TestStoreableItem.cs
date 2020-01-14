using EasyJet.Interview.Interface;

namespace EasyJet.Interview.Tests
{
    public class TestEmployee : IStoreable<int>
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
    }
}
