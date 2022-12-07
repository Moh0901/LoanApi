namespace LoanMicroservice.DTO
{
    public class LoanDTO
    {
        public string? fname { get; set; } // first name
        public string? lname { get; set; } // last name 

        public int lnum { get; set; }   //loan number 

        public string? paddress { get; set; } // property address

        public long lamount { get; set; } // loan amount

        public string? ltype { get; set; } //loan type

        public long lterm { get; set; } //loan term
    }
}
