using LoanMicroservice.DTO;
using LoanMicroservice.Model;
using Microsoft.EntityFrameworkCore;

namespace LoanMicroservice.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext _db;

        public LoanRepository(LoanDbContext db)
        {
            _db = db;

        }

        //Get All Loans 
        public List<Loan> GetAllLoans()
        {
            var loans = _db.loan.ToList();
            return loans;
        }

        //Get Loans By Id
        public Loan GetLoanById(int id)
        {
            var loan = _db.loan.Find(id);
            return loan;
        }

        //Add New Loan 
        public Loan AddLoan(LoanDTO loan)
        {
            var newLoan = new Model.Loan()
            {
                fname = loan.fname,
                lname = loan.lname,
                lnum = loan.lnum,
                paddress = loan.paddress,
                lamount = loan.lamount,
                ltype = loan.ltype,
                lterm = loan.lterm,
            };
            _db.loan.Add(newLoan);
            _db.SaveChanges();
            return newLoan;

        }

        //Update Loan
        public Loan UpdateLoanInfo(int id, LoanDTO loan)
        {
            var updateLoan = new Model.Loan()
            {
                id = id,
                fname = loan.fname,
                lname = loan.lname,
                lnum = loan.lnum,
                paddress = loan.paddress,
                lamount = loan.lamount,
                ltype = loan.ltype,
                lterm = loan.lterm
            };
            /* return updateLoan;*/
            _db.Entry(updateLoan).State = EntityState.Modified;

            _db.SaveChanges();
            return _db.loan.Find(id);
        }

        //Delete Loan
        public Loan DeleteLoan(int id)
        {
            var loan = _db.loan.Find(id);
            if (loan == null)
            {
                return null;
            }
            _db.loan.Remove(loan);
            _db.SaveChanges();
            return loan;
        }
    }
}
