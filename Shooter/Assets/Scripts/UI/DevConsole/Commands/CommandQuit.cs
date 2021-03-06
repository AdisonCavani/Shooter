using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandQuit : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandQuit()
        {
            Name = "Quit";
            Command = "quit";
            Description = "Quits the application";
            Help = "Use this command to quit game without prompt";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            if (Application.isEditor)
            {
#if UNITY_EDITOR
                Debug.Log("Quitting game (command)...");
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
            else
            {
                Debug.Log("Quitting game (command)...");
                Application.Quit();
            }
        }

        public static CommandQuit CreateCommand()
        {
            return new CommandQuit();
        }
    }
}