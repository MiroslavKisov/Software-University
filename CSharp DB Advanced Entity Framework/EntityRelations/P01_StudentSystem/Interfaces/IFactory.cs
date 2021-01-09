using P01_StudentSystem.Data;

namespace P01_StudentSystem.Interfaces
{
    public interface IFactory
    {
        StudentSystemContext CreateContext();
    }
}
