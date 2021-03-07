using System;
namespace MERMS.Models
{
    public class ApprehensionConfiscation
    {
        public int Id { get; set; }
        public string TrackingNo { get; set; }
        public string Jurisdiction { get; set; }
        public string PlaceOfApprehension { get; set; }
        public DateTime? DateOfConfiscation { get; set; }
        public int NumberOfPieces { get; set; }
        public string Species { get; set; }
        public double BoardFeet { get; set; }
        public double CubicMeter { get; set; }
        public string VehiclePlateNo { get; set; }
        public string ParaphernaliaSerialNo { get; set; }
        public string Offender { get; set; }
        public string Address { get; set; }
        public string Custodian { get; set; }
        public string Status { get; set; }
        public string EstimatedValue { get; set; }
        public string Remarks { get; set; }
        public string FilePath { get; set; }
    }
}
