using RoverApllication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RoversApplication.Service
{
    public interface IRoverService
    {
        RoverModel RoverSpinLeft(string position);
        RoverModel RoverSpinRight(string position);
        RoverModel RoverMoveFoward(string position);
        RoverModel Command(string command, string position);
    }
}