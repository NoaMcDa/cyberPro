using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] // so we can see the variables in the inspector
    private GameObject quickStartButton; //button used for creating and joining a game
    [SerializeField]
    private GameObject quickCancelButton;//button used to stop searing for a game to join
    [SerializeField]
    private int RoomSize; //Sets the number of players in the room at once
    
    //Callback function for when the first connection is established 
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true; //Makes it so whatever scene the master client has loaded is the scene all other clients will load  
        quickStartButton.SetActive(true);//acivating the start button
    }

    //this function is paired to the quick start button
    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();/***first tries to join an existing room of game
        if we wouldnt be able to join, the function "on join random failed" ***/
        Debug.Log("Quick start");
    }

    //Callback function for if we fail to join a room
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }
    //trying to create our own room
    void CreateRoom()
    {
        Debug.Log("Creating a new room now");
        int randomRoomNumber = Random.Range(0, 10000);//creating a random name for the room
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); //attempting to create a new room
        Debug.Log(randomRoomNumber);
        //this function triggers a function in "quick start room controller" script.
    }

    //if creating room failed this function is called
    //if it fails it might because we chose a name that already exists
    public override void OnCreateRoomFailed(short returnCode, string message) //callback function for if we fail to create a room. Most likely fail because room name was taken.
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom(); //Retrying to create a new room with a different name.
    }

    //This function is paired to the cancel button. used to stop looking for a room to join, "break button"
    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

}
