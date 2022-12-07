using LoanMicroservice.DTO;
using LoanMicroservice.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LoanMicroservice.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    [EnableCors("AllowOrigin")]
    
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;

        public LoansController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }


        [Authorize(Roles = "Admin,User")]        
        // GET: api/Loans
        [HttpGet]
        public IActionResult Getloan()
        {
            var result = _loanRepository.GetAllLoans();

            if (result == null || result.Count == 0)
            {
                return NotFound("No Loan Exists");
            }

            return Ok(result);
        }

        [Authorize(Roles = "Admin,User")]
        // GET: api/Loans/5
        [HttpGet("{id}")]
        public IActionResult GetLoan(int id)
        {
            var loan = _loanRepository.GetLoanById(id);

            if (loan == null)
            {
                return NotFound("Loan Not Found");
            }

            return Ok(loan);
        }

        [Authorize(Roles = "Admin")]
        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateLoanInfo([FromRoute] int id, [FromBody] DTO.LoanDTO loan)
        {
            if (loan == null)
            {
                return NotFound("Loan Not Found");
            }

            var updatedLoan = _loanRepository.UpdateLoanInfo(id, loan);

            if (updatedLoan != null)
            {
                var updateLoanDTO = new DTO.LoanDTO()
                {
                    fname = updatedLoan.fname,
                    lname = updatedLoan.lname,
                    lnum = updatedLoan.lnum,
                    paddress = updatedLoan.paddress,
                    lamount = updatedLoan.lamount,
                    ltype = updatedLoan.ltype,
                    lterm = updatedLoan.lterm
                };
                return Ok(updateLoanDTO);
            }
            return NotFound("Loan Not Found");

        }

        [Authorize(Roles = "Admin")]
        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostLoan(LoanDTO loan)
        {
            if (loan == null)
            {
                return NotFound("Loan is Empty");
            }
            var newloan = _loanRepository.AddLoan(loan);

            return CreatedAtAction("GetLoan", new { id = newloan.id }, loan);
        }

        [Authorize(Roles = "Admin")]
        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLoan(int id)
        {
            var loan = _loanRepository.DeleteLoan(id);
            if (loan == null)
            {
                return NotFound("Loan Not Found");
            }

            return Ok(loan);
        }
    }
}
