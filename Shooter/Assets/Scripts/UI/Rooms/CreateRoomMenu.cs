using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4; // Max players in rooms
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default); // Error if roomName is empty!
    }

    public override void OnCreatedRoom()
    {
        print("Created room successfuly");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Room creation failed: " + message);
    }
}
