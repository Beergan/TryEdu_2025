using System.Collections.Generic;
using System.Linq;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Abstract;

public static class BasicCodes
{
    public static OptionDuals<string> GenderOptions = new(
        new("M", "Male", "Nam"),
        new("F", "Female", "Nữ"),
        new("U", "Other", "Không xác định")
    );


}