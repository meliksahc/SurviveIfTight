using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 2)
        {
            // Odada 2'den fazla oyuncu varsa, yeni katýlýmcýlarý engelle.
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
  
}
