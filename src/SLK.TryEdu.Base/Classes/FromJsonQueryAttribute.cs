using Microsoft.AspNetCore.Mvc;

namespace SLK.TryEdu.Base;

public class FromJsonQueryAttribute : ModelBinderAttribute
{
    public FromJsonQueryAttribute()
    {
        BinderType = typeof(JsonQueryBinder);
    }
}