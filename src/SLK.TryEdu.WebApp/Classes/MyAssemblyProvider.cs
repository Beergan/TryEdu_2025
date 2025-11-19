using System.Reflection;

namespace SLK.TryEdu.WebApp;

public class MyAssemblyProvider
{
    public static Assembly[] GetBlazorAssemblies()
    {
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        var modules = new List<Assembly>();

        foreach (var dll in loadedAssemblies)
        {
            var name = dll.GetName().Name;
            if (!name.EndsWith("Blazor")) continue;

            if (modules.Any(t => t.GetName().Name == name))
                continue;

            modules.Add(dll);
        }

        return modules.ToArray();
    }
}