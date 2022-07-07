using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Project;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField RoomInputName;
    public GameObject LobbyPanel;
    public GameObject RoomPanel;
    public TMP_Text RoomText;


    public RoomItem roomItemPrefab;
    public List<RoomItem> roomItemList = new List<RoomItem>();

    public Transform ContentObject;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (RoomInputName.text.Length < 4) return;

        PhotonNetwork.CreateRoom(RoomInputName.text, new RoomOptions { MaxPlayers = 8 });

    }

    public override void OnJoinedRoom()
    {
        LobbyPanel.SetActive(false);
        RoomPanel.SetActive(true);
        RoomText.text = "Комната: " + PhotonNetwork.CurrentRoom.Name;
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (var item in roomItemList)
        {
            Destroy(item.gameObject);
        }
        roomItemList.Clear();


        foreach (RoomInfo room in list)
        {
           RoomItem newRoom =  Instantiate(roomItemPrefab, ContentObject);
            newRoom.CreateRoom(room.Name);
            roomItemList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
