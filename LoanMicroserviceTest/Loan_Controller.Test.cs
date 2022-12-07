using LoanMicroservice.Controllers;
using LoanMicroservice.DTO;
using LoanMicroservice.Model;
using LoanMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LoanMicroserviceTest
{
    public class LoanTest
    {
        private MockRepository _repository;
        private Mock<ILoanRepository> _loanRepository;

        [SetUp]
        public void Setup()
        {
            this._repository = new MockRepository(MockBehavior.Strict);
            this._loanRepository = this._repository.Create<ILoanRepository>();
        }
        private LoansController CreateLoanController()
        {
            return new LoansController(this._loanRepository.Object);
        }

        //FOR GET LOAN BY ID TEST
        [Test]
        public void GetLoanId_ShouldReturnOkResult_WhenLoanFound()
        {
            // Arrange   
            var loanController = this.CreateLoanController();
            var loan = new Loan()

            { id = 1, fname = "mohit", lname = "verma", paddress = "ludhiana", lamount = 10000, lnum = 123, lterm = 2, ltype = "home" };
            int Id = 1;

            _loanRepository.Setup(i => i.GetLoanById(Id)).Returns(loan);

            // Act            
            var res = loanController.GetLoan(Id);

            // Assert            
            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void GetLoanId_ShouldReturnNotFound_WhenLoanIsNotFound()
        {    // Arrange           
            var loanController = this.CreateLoanController();
            Loan? loan = null;
            int Id = 1;
            _loanRepository.Setup(i => i.GetLoanById(Id)).Returns(loan);
            //Act

            var res = loanController.GetLoan(Id) as ObjectResult;
            //Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }


        // FOR GET LOAN TEST
        [Test]
        public void GetLoan_ShouldReturnOkResult_WhenLoanFound()
        {
            // Arrange   
            var loanController = this.CreateLoanController();
            var loan = new Loan()
            { id = 1, fname = "mohit", lname = "verma", paddress = "ludhiana", lamount = 10000, lnum = 123, lterm = 2, ltype = "home" };

            var loanlist = new List<Loan>() { loan };
            _loanRepository.Setup(i => i.GetAllLoans()).Returns(loanlist);

            // Act            
            var res = loanController.Getloan();

            // Assert            
            Assert.IsInstanceOf<OkObjectResult>(res);

        }

        [Test]
        public void GetLoan_ShouldReturnNotFound_WhenLoanIsNotFound()
        {
            // Arrange           
            var loanController = this.CreateLoanController();
            List<Loan> loanlist = null;

            _loanRepository.Setup(i => i.GetAllLoans()).Returns(loanlist);

            //Act
            var res = loanController.Getloan() as ObjectResult;

            //Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }

        // FOR LOAN DELETE TEST
        [Test]
        public void DeleteLoan_ShouldReturnOkResult_WhenLoanDeleteSuccess()
        {
            // Arrange
            var loanController = CreateLoanController();

            var loan = new Loan()
            { id = 1, fname = "mohit", lname = "verma", paddress = "ludhiana", lamount = 10000, lnum = 123, lterm = 2, ltype = "home" };
            int Id = 1;

            _loanRepository.Setup(i => i.DeleteLoan(Id)).Returns(loan);

            // Act
            var res = loanController.DeleteLoan(Id) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void DeleteLoan_ShouldReturnNotFound_WhenLoanNotFound()
        {
            // Arrange
            var loanController = CreateLoanController();
            Loan? loan = null;

            int Id = 1;
            _loanRepository.Setup(i => i.DeleteLoan(Id)).Returns(loan);

            // Act
            var res = loanController.DeleteLoan(Id) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }


        //FOR UPDATE LOAN TEST
        [Test]
        public void PutLoan_ShouldReturnOkResult_WhenLoanUpdateSuccess()
        {
            // Arrange
            var loanController = CreateLoanController();
            var loan = new Loan()
            { fname = "mohit", lname = "verma", paddress = "ludhiana", lamount = 10000, lnum = 123, lterm = 2, ltype = "home" };

            int Id = 1;
            var loandto = new LoanDTO()
            { fname = "mohit", lname = "verma", paddress = "ludhiana", lamount = 10000, lnum = 123, lterm = 2, ltype = "home" };

            _loanRepository.Setup(i => i.UpdateLoanInfo(Id, loandto)).Returns(loan);

            // Act
            var res = loanController.UpdateLoanInfo(Id, loandto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void PutLoan_ShouldReturnNotFound_WhenLoanNotFound()
        {
            // Arrange
            var loanController = CreateLoanController();
            Loan? loan = null;
            int Id = 1;

            LoanDTO? loandto = null;
            _loanRepository.Setup(i => i.UpdateLoanInfo(Id, loandto)).Returns(loan);

            // Act
            var res = loanController.UpdateLoanInfo(Id, loandto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }


        // FOR ADD LOAN TEST
        [Test]
        public void PostLoan_ShouldReturnCreatedResult_WhenLoanCreationSuccess()
        {
            // Arrange
            var loanController = CreateLoanController();
            var loan = new Loan()
            { fname = "mohit", lname = "verma", paddress = "ludhiana", lamount = 10000, lnum = 123, lterm = 2, ltype = "home" };

            var loandto = new LoanDTO()
            { fname = "mohit", lname = "verma", paddress = "ludhiana", lamount = 10000, lnum = 123, lterm = 2, ltype = "home" };

            _loanRepository.Setup(i => i.AddLoan(loandto)).Returns(loan);

            // Act
            var res = loanController.PostLoan(loandto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(res);
        }

        [Test]
        public void PostLoan_ShouldReturnNotFOund_WhenWePostEmptyLoan()
        {
            // Arrange
            var loanController = CreateLoanController();
            Loan? loan = null;
            LoanDTO? loandto = null;

            _loanRepository.Setup(i => i.AddLoan(loandto)).Returns(loan);

            // Act
            var res = loanController.PostLoan(loandto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }
    }
}