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

    public List<PlayerItem> playerItemList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    public GameObject PlayBtn;
    public bool isOneStart;
    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (RoomInputName.text.Length < 4) return;

        PhotonNetwork.CreateRoom(RoomInputName.text, new RoomOptions { MaxPlayers = 8, BroadcastPropsChangeToAll = true });

    }

    public override void OnJoinedRoom()
    {
        LobbyPanel.SetActive(false);
        RoomPanel.SetActive(true);
        RoomText.text = "Комната: " + PhotonNetwork.CurrentRoom.Name;

        UpdatePLayerList();
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);

    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePLayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePLayerList();
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

    private void UpdatePLayerList()
    {
        foreach (var item in playerItemList)
        {
            Destroy(item.gameObject);
        }
        playerItemList.Clear();


        if (PhotonNetwork.CurrentRoom == null) return;

        foreach (var item in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetName(item.Value);

            if(item.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyChanges();
            }
            playerItemList.Add(newPlayerItem);
        }
        if (!isOneStart)
        {
            if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
            {
                PlayBtn.gameObject.SetActive(true);
            }
            else
            {
                PlayBtn.gameObject.SetActive(false);
            }
        }
        else
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PlayBtn.gameObject.SetActive(true);
            }
            else
            {
                PlayBtn.gameObject.SetActive(false);
            }
        }


    }

    public void OnClickPlayButton()
    {
        PhotonNetwork.LoadLevel("Game 1");
    }
}
