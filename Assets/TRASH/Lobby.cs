using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    public Text LogText;
    public GameObject buttons;
    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1, 9999);
        PhotonNetwork.GameVersion = "1";
        Log(PhotonNetwork.NickName+" - ��������������� �������");
        Log("...�������� ���������...");
        PhotonNetwork.ConnectUsingSettings();
        buttons.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        Log("����� � �����������! ������� ������ ������� ��� ��������������!");
        buttons.SetActive(true);
    }

    public override void OnCreatedRoom()
    {
        Log("������� �������");
    }

    public override void OnJoinedRoom()
    {
        Log("������������� � �������");
        PhotonNetwork.LoadLevel(1);
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 4 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    private void Log(string message)
    {
        LogText.text += "\n" + message;
    }
}
