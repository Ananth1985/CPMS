namespace CPMS.Web.Models
{
    public class PlacementRequestDetails
    {
        public int PlacementRequestDetailsId { get; set; }
        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public decimal CGPA { get; set; }

        public int Arrears { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
