using System;
using System.Collections.Generic;
using System.Reflection;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Base;

public class GlobalPermissions
{
    public static Dictionary<FeatureModel, Tuple<long, string, string>[]> Dictionary = new();

    public static void Add(FeatureModel key, Tuple<long, string, string>[] values) => Dictionary.Add(key, values);

    public static void Register(Type enumType)
    {
        var featureAttribute = (FeatureAttribute)Attribute.GetCustomAttribute(enumType, typeof(FeatureAttribute));
        if (featureAttribute == null)
        {
            return;
        }

        var items = new List<Tuple<long, string, string>>();

        foreach (var functionName in Enum.GetNames(enumType))
        {
            var member = enumType.GetMember(functionName);
            var obsoleteAttribute = member[0].GetCustomAttribute<ObsoleteAttribute>();
            if (obsoleteAttribute != null)
                continue;

            var funcAttribute = member[0].GetCustomAttribute<Function>();
            if (funcAttribute == null)
                continue;

            var permissionNo = Convert.ToInt64(Enum.Parse(enumType, functionName, false));
            var permissionValue = Convert.ToInt64(Math.Pow(2, permissionNo));
            items.Add(new(permissionValue, funcAttribute.TextEn, funcAttribute.TextVi));
        }

        var feature = new FeatureModel { Name = featureAttribute.Name, TextEn = featureAttribute.TextEn, TextVi = featureAttribute.TextVi };
        GlobalPermissions.Add(feature, items.ToArray());
    }
}