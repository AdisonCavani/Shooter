using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairColor : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairColor()
        {
            Name = "Crosshair color ";
            Command = "cl_crosshaircolor";
            Description = "Change crosshair color";
            Help = "Use this command to change crosshair color:\n" +
                "0 - red\n" +
                "1 - green\n" +
                "2 - yellow\n" +
                "3 - blue\n" +
                "4 - cyan\n" +
                "5 - custom";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");
            var crosshair = obj.GetComponent<Crosshair>();

            if (argument == "0")
            {
                crosshair.crosshairColor = Color.red;
            }

            else if (argument == "1")
            {
                crosshair.crosshairColor = Color.green;
            }

            else if (argument == "2")
            {
                crosshair.crosshairColor = Color.yellow;
            }

            else if (argument == "3")
            {
                crosshair.crosshairColor = Color.blue;
            }

            else if (argument == "4")
            {
                crosshair.crosshairColor = Color.cyan;
            }

            else if (argument == "5")
            {
                crosshair.crosshairColor = Color.green; // TODO: Add custom color here
            }

            else
            {
                Debug.LogWarning("Value out of range (0 - 5)");
            }

        }

        public static CommandCrosshairColor CreateCommand()
        {
            return new CommandCrosshairColor();
        }
    }
}