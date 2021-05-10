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
                "0 - <color=red>red</color>\n" +
                "1 - <color=green>green</color>\n" +
                "2 - <color=yellow>yellow</color>\n" +
                "3 - <color=blue>blue</color>\n" +
                "4 - <color=#00ffff>cyan</color>\n" +
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
                crosshair.customColor = 0;
            }

            else if (argument == "1")
            {
                crosshair.customColor = 1;
            }

            else if (argument == "2")
            {
                crosshair.customColor = 2;
            }

            else if (argument == "3")
            {
                crosshair.customColor = 3;
            }

            else if (argument == "4")
            {
                crosshair.customColor = 4;
            }

            else if (argument == "5")
            {
                crosshair.customColor = 5;
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