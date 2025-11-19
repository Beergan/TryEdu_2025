using System;
using System.ComponentModel.DataAnnotations;
using Syncfusion.Blazor.PdfViewerServer;

namespace SLK.TryEdu.Abstract;

public class ModelPets
{
    public Guid Guid { get; set; }
    [Required(ErrorMessage = "Tên thú cưng là bắt buộc.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Loại thú cưng là bắt buộc.")]
    public string Species { get; set; }
    public string Breed { get; set; }
    [Range(0, 100, ErrorMessage = "Tuổi phải từ 0 đến 100.")]
    public int Age { get; set; }
    [Required(ErrorMessage = "Giới tính là bắt buộc.")]
    public string Gender { get; set; }
    public string Color { get; set; }
    public int Id { get; set; }
    public string Microchip { get; set; }
    public string MedicalNotes { get; set; }
    public bool IsDeleted { get; set; } = false;
    public Guid PetTypeGuid { get; set; }
}