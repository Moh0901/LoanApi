using Microsoft.AspNetCore.Mvc;
using Moq;
using UserMicroservice.Controllers;
using UserMicroservice.DTO;
using UserMicroservice.Model;
using UserMicroservice.Repository;

namespace UserMicrroserviceTest
{
    public class UserTest
    {
        private MockRepository _repository;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            this._repository = new MockRepository(MockBehavior.Strict);
            this._userRepository = this._repository.Create<IUserRepository>();
        }
        private UsersController CreateUserController()
        {
            return new UsersController(this._userRepository.Object);
        }

        //FOR GET USER BY ID TEST
        [Test]
        public void GetUserId_ShouldReturnOkResult_WhenUserFound()
        {
            // Arrange   
            var userController = this.CreateUserController();
            var user = new User()
            { id = 1, name = "mohit", username = "abcteree", password = "whqihd", role = "admin" };

            int Id = 1;
            _userRepository.Setup(i => i.GetUserById(Id)).Returns(user);

            // Act            
            var res = userController.GetUser(Id);

            // Assert            
            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void GetUserId_ShouldReturnNotFound_WhenUserIsNotFound()
        {
            // Arrange           
            var userController = this.CreateUserController();
            User? user = null;

            int Id = 1;
            _userRepository.Setup(i => i.GetUserById(Id)).Returns(user);

            //Act
            var res = userController.GetUser(Id) as ObjectResult;

            //Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }


        // FOR USER GET TEST
        [Test]
        public void GetUser_ShouldReturnOkResult_WhenUserFound()
        {
            // Arrange   
            var userController = this.CreateUserController();
            var user = new User()
            { id = 1, name = "mohit", username = "abcteree", password = "whqihd", role = "admin" };

            var userList = new List<User>() { user };
            _userRepository.Setup(i => i.GetAllUsers()).Returns(userList);

            // Act            
            var res = userController.Getuser();

            // Assert            
            Assert.IsInstanceOf<OkObjectResult>(res);

        }

        [Test]
        public void GetUser_ShouldReturnNotFound_WhenUserIsNotFound()
        {
            // Arrange           
            var userController = this.CreateUserController();
            List<User> userList = null;

            _userRepository.Setup(i => i.GetAllUsers()).Returns(userList);

            //Act
            var res = userController.Getuser() as ObjectResult;

            //Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }

        // FOR USER DELETE TEST
        [Test]
        public void DeleteUser_ShouldReturnOkResult_WhenUserDeleteSuccess()
        {
            // Arrange
            var userController = CreateUserController();

            var user = new User()
            { id = 1, name = "mohit", username = "abcteree", password = "whqihd", role = "admin" };
            int Id = 1;

            _userRepository.Setup(i => i.DeleteUser(Id)).Returns(user);

            // Act
            var res = userController.DeleteUser(Id) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void DeleteUser_ShouldReturnNotFound_WhenUserNotFound()
        {
            // Arrange
            var userController = CreateUserController();
            User? user = null;

            int Id = 1;
            _userRepository.Setup(i => i.DeleteUser(Id)).Returns(user);

            // Act
            var res = userController.DeleteUser(Id) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }


        //FOR UPDATE USER TEST
        [Test]
        public void PutUser_ShouldReturnOkResult_WhenUserUpdateSuccess()
        {
            // Arrange
            var userController = CreateUserController();
            var user = new User()
            { name = "mohit", username = "abcteree", password = "whqihd", role = "admin" };

            int Id = 1;
            var userdto = new UserDTO()
            { name = "mohit", username = "abcteree", password = "whqihd", role = "admin" };

            _userRepository.Setup(i => i.UpdateUser(Id, userdto)).Returns(user);

            // Act
            var res = userController.UpdateUser(Id, userdto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public void PutUser_ShouldReturnNotFound_WhenUserNotFound()
        {
            // Arrange
            var userController = CreateUserController();
            User? user = null;
            int Id = 1;

            UserDTO? userdto = null;
            _userRepository.Setup(i => i.UpdateUser(Id, userdto)).Returns(user);

            // Act
            var res = userController.UpdateUser(Id, userdto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }


        // FOR ADD USER TEST
        [Test]
        public void PostUser_ShouldReturnCreatedResult_WhenUserCreationSuccess()
        {
            // Arrange
            var userController = CreateUserController();
            var user = new User()
            { name = "mohit", username = "abcteree", password = "whqihd", role = "admin" };

            var userdto = new UserDTO()
            { name = "mohit", username = "abcteree", password = "whqihd", role = "admin" };

            _userRepository.Setup(i => i.AddUser(userdto)).Returns(user);

            // Act
            var res = userController.PostUser(userdto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(res);
        }

        [Test]
        public void PostUser_ShouldReturnNotFOund_WhenWeUserEmptyLoan()
        {
            // Arrange
            var userController = CreateUserController();
            User? user = null;
            UserDTO? userdto = null;

            _userRepository.Setup(i => i.AddUser(userdto)).Returns(user);

            // Act
            var res = userController.PostUser(userdto) as ObjectResult;

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(res);
        }
    }
}