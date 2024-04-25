using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NewNetworkController : MonoBehaviour
{
    [Header("GO")]
    public GameObject loginGo;
    public GameObject partidasGo;
    public GameObject informationGo;

    [Header("Player")]
    public InputField playerNameInput;
    private string playerNameTemp;
    public GameObject myPlayer;

    [Header("Room")]
    public InputField roomName;

    [Header("Informacao")]
    public Text info;
    public Text textInfo;

    [Header("Pontuacao")]
    public int pontos;

    public void Start(){
        PhotonNetwork.ConnectUsingSettings();
        PhotonNeetwork.ConnectToRegion("sa");
        playerNameTemp = "Player" + Random.Range(1000, 10000);
        playerNameInput.text = playerNameTemp;

        roomName.text = "Sala" + Random.Range(1000, 10000);

        loginGo.GameObject.SetActive(true);
        partidasGo.GameObject.SetActive(true);
        informationGo.GameObject.SetActive(true);
    }

    void Update(){

    }

    public void BtLogin() {
        if(playerNameInput.text != ""){
            PhotonNetwork.NickName = playerNameInput.text;
            Debug.Log("Player: " + PhotonNetwork.NickName);
        }
        else {

        }
    }

    public void BtBuscarPartidaRapida() {
        PhotonNetwork.JoinLobby();
    }

    public void BtCriarSala() {
        string roomNameTemp = roomName.text;
        RoomOptions roomOptions = new RoomOptions() {MaxPlayers = 20};
        PhotonNetwork.JoinOrCreateRoom(roomNameTemp, roomOptions, TypedLobby.Default);
    }

    public override void OnConnected()
    {
        Debug.Log("Conectado ao servidor");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado ao Master");
        
    }
}