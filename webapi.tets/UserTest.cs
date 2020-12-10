using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
namespace webapi.tests
{
    public class UserTest
    {
        [Fact]
        public void UserGet(){
            // AAA Arrange (Preparar), Act (Actuar), Assert (Afirmar).
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);

            var result = userController.Get();

            Assert.NotEmpty(result);
        }
        [Fact]
        public void UserGetById_BadRequest(){
            // AAA Arrange (Preparar), Act (Actuar), Assert (Afirmar).
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);

            var result = userController.Get("");

            Assert.IsType<BadRequestResult>(result.Result);
        }
        [Fact]
        public void UserGetById_Ok(){
            
            using var apiContext = ApiTestContext.GetApiAppContext();
            var userController = new UserController(apiContext);
            var firtsId = userController.Get().ToList()[0].userId;

            var result = userController.Get(firtsId.ToString());

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}