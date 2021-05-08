using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairColorG : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairColorG()
        {
            Name = "Crosshair color green value";
            Command = "cl_crosshaircolor_g";
            Description = "Change green value in crosshair color";
            Help = "Use this command to change green value in crosshair color";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");

            var crosshair = obj.GetComponent<Crosshair>();
            crosshair.crosshairColor.g = (byte)Mathf.Clamp(byte.Parse(argument), 0, 255);
        }

        public static CommandCrosshairColorG CreateCommand()
        {
            return new CommandCrosshairColorG();
        }
    }
}