using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairColorR : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairColorR()
        {
            Name = "Crosshair color red value";
            Command = "cl_crosshaircolor_r";
            Description = "Change red value in crosshair color";
            Help = "Use this command to change red value in crosshair color";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {

        }

        public static CommandCrosshairColorR CreateCommand()
        {
            return new CommandCrosshairColorR();
        }
    }
}