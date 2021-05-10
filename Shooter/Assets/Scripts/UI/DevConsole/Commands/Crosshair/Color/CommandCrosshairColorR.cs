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
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");

            var crosshair = obj.GetComponent<Crosshair>();
            crosshair.redColorValue = (byte)Mathf.Clamp(int.Parse(argument), 0, 255);
        }

        public static CommandCrosshairColorR CreateCommand()
        {
            return new CommandCrosshairColorR();
        }
    }
}