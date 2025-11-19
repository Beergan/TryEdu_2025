using System.Reflection;

namespace SLK.TryEdu.Abstract;

public interface IAssemblyProvider
{
    Assembly[] GetAssemblies();
}