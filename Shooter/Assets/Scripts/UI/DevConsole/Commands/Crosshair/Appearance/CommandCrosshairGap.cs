using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairGap : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairGap()
        {
            Name = "Crosshair gap";
            Command = "cl_crosshairgap";
            Description = "Change crosshair gap";
            Help = "Use this command to change crosshair gap";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");
            var crosshair = obj.GetComponent<Crosshair>();

            crosshair.gap = uint.Parse(argument);
        }

        public static CommandCrosshairGap CreateCommand()
        {
            return new CommandCrosshairGap();
        }
    }
}