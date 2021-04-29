using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandDisconnect : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public CommandDisconnect()
        {
            Name = "Disconnect";
            Command = "disconnect";
            Description = "Disconnect from server and go to main menu";
            Help = "Use this command to disconnect from server and go to main menu";

            AddCommandToConsole();
        }

        public override void RunCommand(string[] args)
        {
            if (PhotonNetwork.IsConnected)
            {
                Debug.Log("Disconnected from server (command)");
                PhotonNetwork.Disconnect();
                PhotonNetwork.LoadLevel(0);
            }
        }

        public static CommandDisconnect CreateCommand()
        {
            return new CommandDisconnect();
        }
    }
}