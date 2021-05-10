using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairSize : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairSize()
        {
            Name = "Crosshair size";
            Command = "cl_crosshairsize";
            Description = "Change crosshair size";
            Help = "Use this command to change crosshair size";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");
            var crosshair = obj.GetComponent<Crosshair>();

            crosshair.size = uint.Parse(argument);
        }

        public static CommandCrosshairSize CreateCommand()
        {
            return new CommandCrosshairSize();
        }
    }
}