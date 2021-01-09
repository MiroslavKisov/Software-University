using P01_StudentSystem.Data;
using P01_StudentSystem.Interfaces;

namespace P01_StudentSystem.Factories
{
    public class ContextFactory : IFactory
    {
        public StudentSystemContext CreateContext()
        {
            return new StudentSystemContext();
        }
    }
}
