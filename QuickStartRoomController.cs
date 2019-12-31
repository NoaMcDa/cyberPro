using Photon.Pun;
using UnityEngine;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex; //Number of the build index of the multiplayer scene

    //using a callback function that is being triggered on our 'lobby controller' script.
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);  
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    //callback function for when we successfully create or join a room.
    public override void OnJoinedRoom() 
    {
        Debug.Log("Joined Room");
        StartGame();
    }
   //Function for loading into the multiplayer scene.
    private void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)//checking if we are on the master client
        {
            //load into the multiplayer scene
            Debug.Log("Starting Game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex); //because of AutoSyncScene all players who join the room will also be loaded into the multiplayer scene.
        }
    }



}
