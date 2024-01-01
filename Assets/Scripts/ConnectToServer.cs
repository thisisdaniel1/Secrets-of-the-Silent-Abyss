using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // called when client connects to server
    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();
    }

    // once client has connected to the server, he/she will be redirected to the lobby
    public override void OnJoinedLobby(){
        SceneManager.LoadScene("Lobby");
    }
}
