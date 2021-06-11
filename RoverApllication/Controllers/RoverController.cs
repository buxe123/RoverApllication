using Microsoft.AspNetCore.Mvc;
using RoverApllication.Models;
using RoversApplication.Service;
using System;

namespace RoverApllication.Controllers
{
    public class RoverController : Controller
    {
        private readonly IRoverService _roverService;
        public RoverController(IRoverService roverService)
        {
            _roverService = roverService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputCommand,string position)
        {
            try
            {

                switch(inputCommand)
                {
                    case "RoverSpinLeft":
                        {
                           var model = _roverService.RoverSpinLeft(position);
                            return Json(new RoverModel { Direction = model.Direction, X = model.X, Y = model.Y });
                        }
                    case "RoverSpinRight":
                        {
                            var model = _roverService.RoverSpinRight(position);
                            return Json(new RoverModel { Direction = model.Direction, X = model.X, Y = model.Y });

                        }
                    case "RoverMoveFoward":
                        {
                            var model =  _roverService.RoverMoveFoward(position);
                            return Json(new RoverModel { Direction = model.Direction, X = model.X, Y = model.Y });

                        }                
                    default:
                        {
                            throw new IndexOutOfRangeException(); 
                            
                        }
                }
             
            }
            catch(Exception e)
            {
                
                return BadRequest("error ocurred" + e.Message);
            }
        }

        [HttpPost]
        public IActionResult Command(string inputCommand, string position)
        {
            var model = _roverService.Command(inputCommand, position);
            return Json(new RoverModel { Direction = model.Direction, X = model.X, Y = model.Y });

        }


    }
}

