using System;
using System.Collections.Generic;

namespace SLK.TryEdu.Abstract;

public class ModelListCustomer
{
    public  Guid Guid { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Id { get; set; }
    public string Avatar { get; set; }
    public string Address { get; set; }

    public string CitizenID { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Note { get; set; }
    public bool IsDeleted { get; set; } = false;
    public ICollection<ModelPets> Pets { get; set; } = new List<ModelPets>();
}