using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RoverApllication.Controllers;
using RoverApllication.Models;
using RoversApplication.Service;
using System.Net.Http;

namespace RoverApplicationTest
{
    [TestFixture]

    public class RoverAppTests
    {


        [Test]
        public void RoverSpinLeft()
        {
            //Arrange
            var roverService = new RoverService(new RoverApllication.Models.RoverModel());
            var roverController = new RoverController(roverService);

            //Asset
            var response = roverController.Index("RoverSpinLeft", "1 2 N") as JsonResult;
            var model = response.Value as RoverModel;

            //Act
            Assert.AreEqual("W", model.Direction);

        }

        [Test]
        public void RoverSpinRight()
        {
            //Arrange
            var roverService = new RoverService(new RoverApllication.Models.RoverModel());
            var roverController = new RoverController(roverService);

            //Asset
            var response = roverController.Index("RoverSpinRight", "1 2 N") as JsonResult;
            var model = response.Value as RoverModel;

            //Act
            Assert.AreEqual("E", model.Direction);
        }

        [Test]
        public void RoverMoveFoward()
        {
            //Arrange
            var roverService = new RoverService(new RoverApllication.Models.RoverModel());
            var roverController = new RoverController(roverService);

            //Asset
            var response = roverController.Index("RoverMoveFoward", "1 2 N") as JsonResult;
            var model = response.Value as RoverModel;


            //Act
            Assert.AreEqual(3, model.Y);
        }


        [Test]
        public void Command()
        {

            //Arrange
            var roverService = new RoverService(new RoverApllication.Models.RoverModel());
            var roverController = new RoverController(roverService);

            //Asset
            var response = roverController.Command("LMLMLMLMM", "1 2 N") as JsonResult; // input command LMLMLMLMM or  MMRMMRMRRM
            var model = response.Value as RoverModel;

            //Act
            Assert.AreEqual("1 3 N", model.X + " " + model.Y + " " + model.Direction);
        }
    }
}