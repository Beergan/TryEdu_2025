using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SLK.TryEdu.Abstract;

public class ModelSubmitSample
{
    public Guid Guid { get; set; }

    public string LaneNo { get; set; }

    public string TruckNo { get; set; }

    public string TrailerNo { get; set; }

    public string CntrNo1 { get; set; }

    public string CntrNo2 { get; set; }

    public string Status { get; set; }
}