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



    public static OptionDuals<string> PetSpeciesOptions = new(
          new OptionDual<string>("Dog", "Dog", "Chó"),
          new OptionDual<string>("Cat", "Cat", "Mèo"),
          new OptionDual<string>("Bird", "Bird", "Chim"),
          new OptionDual<string>("Other", "Other", "Khác")
      );



}