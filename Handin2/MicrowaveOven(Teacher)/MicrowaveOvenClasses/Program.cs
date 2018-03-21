using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using Timer = MicrowaveOvenClasses.Boundary.Timer;


namespace MicrowaveOvenClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup all the objects, 
            var output = new Output();
            var door = new Door();
            var pButton = new Button();
            var tButton = new Button();
            var scButton = new Button();
            var display = new Display(output);
            var powerTube = new PowerTube(output);
            var timer = new Timer();
            var cookController = new CookController(timer, display, powerTube);
            var light = new Light(output);
            var userInterface = new UserInterface(pButton, tButton, scButton, door, display, light, cookController);

            // Simulate user activities
            door.Open();
            door.Close();
            pButton.Press();
            tButton.Press();
            tButton.Press();
            scButton.Press();
            Thread.Sleep(2000);

            // Wait while the classes, including the timer, do their job
            System.Console.WriteLine("Tast enter når applikationen skal afsluttes");
            System.Console.ReadLine();

        }
    }
}
