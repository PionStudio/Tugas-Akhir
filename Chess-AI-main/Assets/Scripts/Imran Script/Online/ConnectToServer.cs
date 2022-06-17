using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private int maxPlayers = 2;

    // Start is called before the first frame update
    void Start()
    {
        //Connect To Server
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            return;
        }

        PhotonNetwork.JoinRandomRoom();

    }

    #region Connecting To Server Lobby
    public override void OnConnectedToMaster()
    {
        Debug.Log("We Just Connected to Phtoton Server on " + PhotonNetwork.CloudRegion + " Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        QuickMatch();
    }
    #endregion

    #region Connect or Create Room

    private void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    private void CreateRoom()
    {
        //string[] expectedUsers = new string[] { "2" };
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.CreateRoom(null, roomOptions, null);
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully Joined a room with "+ PhotonNetwork.CountOfPlayersInRooms.ToString() +" people in it");

        // Joined a room with other people inside
        if (PhotonNetwork.CountOfPlayersInRooms > 0)
        {
            PhotonNetwork.LoadLevel("Chess Online");
        }

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No Room available, we are creating a Room");
        CreateRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PhotonNetwork.LoadLevel("Chess Online");
    }
    #endregion

}
