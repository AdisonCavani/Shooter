using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandQuitPrompt : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandQuitPrompt()
        {
            Name = "Quit Prompt";
            Command = "quit_prompt";
            Description = "Quits the application";
            Help = "Use this command to quit game with prompt";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            GameObject.Find("ExitMenuPrompt").transform.GetChild(0).gameObject.SetActive(true);
        }

        public static CommandQuitPrompt CreateCommand()
        {
            return new CommandQuitPrompt();
        }
    }
}