using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandCrosshairAlpha : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandCrosshairAlpha()
        {
            Name = "Crosshair color alpha value";
            Command = "cl_crosshairalpha";
            Description = "Change alpha value in crosshair color";
            Help = "Use this command to change alpha value in crosshair color";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            string argument = args[0];

            var obj = GameObject.Find("Crosshair");

            var crosshair = obj.GetComponent<Crosshair>();
            crosshair.alphaColorValue = (byte)Mathf.Clamp(int.Parse(argument), 0, 255);
        }

        public static CommandCrosshairAlpha CreateCommand()
        {
            return new CommandCrosshairAlpha();
        }
    }
}