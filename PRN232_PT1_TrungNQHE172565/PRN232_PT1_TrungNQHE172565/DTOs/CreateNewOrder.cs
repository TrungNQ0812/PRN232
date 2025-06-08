using PRN232_PT1_TrungNQHE172565.Models;

namespace PRN232_PT1_TrungNQHE172565.DTOs
{
    public class CreateNewOrder
    {
        public string? Status { get; set; }

        public DateOnly? OrderDate { get; set; }

        public int? EmpId { get; set; }
    }
}
