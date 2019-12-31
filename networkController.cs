using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class networkController : MonoBehaviourPunCallbacks
{

    //Documentation: https://doc.photonengine.com/en-us/pun/current/getting-started/pun-intro
    //Scripting API: https://doc-api.photonengine.com/en/pun/v2/index.html

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//connects to the photon network servers
    }

    //this function shows us on the console to which reigon we are connected right now
    public override void OnConnectedToMaster()
    {
        Debug.Log("we are now connected to the " + PhotonNetwork.CloudRegion + " server."); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
