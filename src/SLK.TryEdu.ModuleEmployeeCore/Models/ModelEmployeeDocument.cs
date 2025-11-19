using System;

namespace SLK.TryEdu.ModuleEmployeeCore;

public class ModelEmployeeDocument
{
    public Guid Guid { get; set; }

    public int Id { get; set; }

    public Guid GuidEmployeePost { get; set; }

    public string NameEmployeePost { get; set; }

    public Guid GuidEmployee { get; set; }

    public string NameFile { get; set; }

    public string TypeFile { get; set; }

    public string FolderName { get; set; }

    public DateTime DateCreated { get; set; }
}