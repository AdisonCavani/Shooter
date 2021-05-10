using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairColorB : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairColorB()
        {
            Name = "Crosshair color blue value";
            Command = "cl_crosshaircolor_b";
            Description = "Change blue value in crosshair color";
            Help = "Use this command to change blue value in crosshair color";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");

            var crosshair = obj.GetComponent<Crosshair>();
            crosshair.blueColorValue = (byte)Mathf.Clamp(int.Parse(argument), 0, 255);
        }

        public static CommandCrosshairColorB CreateCommand()
        {
            return new CommandCrosshairColorB();
        }
    }
}