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
            cookController.UI = userInterface;


            // Simulate user activities
            Console.WriteLine("Let's cook some food!\n");
            door.Open();
            door.Close();
            pButton.Press();
            Thread.Sleep(2000);
            pButton.Press();
            Thread.Sleep(500);
            pButton.Press();
            Thread.Sleep(500);
            pButton.Press();
            Thread.Sleep(500);
            pButton.Press();
            Thread.Sleep(2000);
            tButton.Press();
            scButton.Press();
            Thread.Sleep(5000);
            Console.Write("Nah, wrong settings ..\n\n");
            scButton.Press();
            Thread.Sleep(2000);
            pButton.Press();
            pButton.Press();
            tButton.Press();
            scButton.Press();
            Thread.Sleep(5000);
            Console.WriteLine("Nvm, not hungry\n");
            door.Open();
            Console.WriteLine("Or maybe I am\n");
            Thread.Sleep(1000);
            door.Close();
            Thread.Sleep(3000);
            pButton.Press();
            tButton.Press();
            scButton.Press();
            Thread.Sleep(1000 * 61);
            Console.WriteLine("FOOD!\n");
            door.Open();

        }
    }
}
