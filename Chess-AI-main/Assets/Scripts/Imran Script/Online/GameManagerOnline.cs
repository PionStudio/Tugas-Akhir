using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManagerOnline : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaveOnlineRoom()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Main Menu");
        Debug.Log("Player currently on room is " + PhotonNetwork.CountOfPlayersInRooms.ToString());
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        LeaveOnlineRoom();
    }
}
