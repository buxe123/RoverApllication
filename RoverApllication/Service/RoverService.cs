using RoverApllication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace RoversApplication.Service
{
    public class RoverService : IRoverService
    {
        private readonly RoverModel _roverModel;

        public RoverService(RoverModel roverModel)
        {
            _roverModel = new RoverModel();
        }

        public RoverModel RoverSpinLeft(string inputDirection)
        {
            string direction;
            int X = 0;
            int Y = 0;
            
            Int32.TryParse(inputDirection.Split(" ")[0], out X);
            Int32.TryParse(inputDirection.Split(" ")[1], out Y);
            direction = inputDirection.Split(" ")[2];
          


            switch (direction)
            {
                case "N":
                    _roverModel.Direction = "W";
                    _roverModel.X = X;
                    _roverModel.Y = Y;
                    break;

                case "W":
                    _roverModel.Direction = "S";
                    break;

                case "S":
                    _roverModel.Direction = "E";
                    break;

                case "E":
                    _roverModel.Direction = "N";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return _roverModel;
        }
        public RoverModel RoverSpinRight(string inputDirection)
        {
            Int32.TryParse(inputDirection.Split(" ")[0], out int X);
            Int32.TryParse(inputDirection.Split(" ")[1], out int Y);
            var direction = inputDirection.Split(" ")[2];


            switch (direction)
            {
                case "N":
                    _roverModel.Direction = "E";
                    break;

                case "E":
                    _roverModel.Direction = "S";
                    break;

                case "S":
                    _roverModel.Direction = "W";
                    break;

                case "W":
                    _roverModel.Direction = "N";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
            return _roverModel;
        }
        public RoverModel RoverMoveFoward(string inputDirection)
        {

            Int32.TryParse(inputDirection.Split(" ")[0], out int X);
            Int32.TryParse(inputDirection.Split(" ")[1], out int Y);
            var direction = inputDirection.Split(" ")[2];
            _roverModel.Y = Y;
            _roverModel.X = X;

            switch (direction)
            {

                case "N":
                    _roverModel.Y = _roverModel.Y + 1;
                    _roverModel.Direction = "N";
                    break;

                case "E":
                    _roverModel.X = _roverModel.X + 1;
                    _roverModel.Direction = "E";
                    break;

                case "S":
                    _roverModel.Y = _roverModel.Y - 1;
                    _roverModel.Direction = "S";
                    break;

                case "W":
                    _roverModel.X = _roverModel.X - 1;
                    _roverModel.Direction = "W";

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return _roverModel;
        }
        public RoverModel Command(string command, string inpuDirection)
        {

            var strCommand = command.Replace(" ", "");

            var roverCommand = strCommand.ToCharArray().Distinct(); ;

            foreach (var c in roverCommand)
            {
                switch (c)
                {
                    case 'R':
                        {
                            RoverSpinRight(inpuDirection);
                            break;
                        }
                    case 'L':
                        {
                            RoverSpinLeft(inpuDirection);
                            break;
                        }
                    case 'M':
                        {
                            RoverMoveFoward(inpuDirection);
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return _roverModel;
        }


    }
}
