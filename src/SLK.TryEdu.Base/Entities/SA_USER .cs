    using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLK.TryEdu.Abstract;

public class SA_USER : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Note { get; set; }
    public Guid? GuidEmployee { get; set; }
    public bool EmployeeConnected { get; set; }
    public string Avatar { get; set; }
    public bool Active { get; set; }
}