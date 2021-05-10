using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairDot : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairDot()
        {
            Name = "Crosshair dot";
            Command = "cl_crosshairdot";
            Description = "Enable or disable crosshair dot";
            Help = "Use this command to enable or disable crosshair dot";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");
            var crosshair = obj.GetComponent<Crosshair>();

            if (argument == "0")
            {
                crosshair.dot = false;
            }

            else if (argument == "1")
            {
                crosshair.dot = true;
            }

            else
            {
                Debug.LogWarning("Value out of range (0 - 1)");
            }

        }

        public static CommandCrosshairDot CreateCommand()
        {
            return new CommandCrosshairDot();
        }
    }
}