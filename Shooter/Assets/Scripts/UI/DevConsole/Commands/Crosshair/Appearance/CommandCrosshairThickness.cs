using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairThickness : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairThickness()
        {
            Name = "Crosshair thickness";
            Command = "cl_crosshairthickness";
            Description = "Change crosshair thickness";
            Help = "Use this command to change crosshair thickness";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");
            var crosshair = obj.GetComponent<Crosshair>();

            crosshair.thickness = uint.Parse(argument);
        }

        public static CommandCrosshairThickness CreateCommand()
        {
            return new CommandCrosshairThickness();
        }
    }
}