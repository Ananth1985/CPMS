namespace CPMS.Contracts.Models
{
    public class PlacementRequest
    {
        public int PlacementRequestId { get; set; }

        public int CollegeId { get; set; }

        public string? CollegeName { get; set; }

        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }

        public DateTime? RequestedDate { get; set; }

        public string DepartmentIds { get; set; }

        public decimal CGPA { get; set; }

        public int Arrears { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public List<PlacementRequestDetails> PlacementDetails { get; set; }
    }
}
