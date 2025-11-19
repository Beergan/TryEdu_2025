using System;

namespace SLK.TryEdu.Abstract;

public class FeatureAttribute : Attribute
{
    public string Name { get; set; }
    
    public string TextEn { get; set; }

    public string TextVi { get; set; }
}

public class FeatureModel
{
    public string Name { get; set; }
    
    public string TextEn { get; set; }

    public string TextVi { get; set; }
}

public class Function : Attribute
{
    public string TextEn { get; set; }

    public string TextVi { get; set; }
}