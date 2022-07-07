using UnityEngine;
using TMPro;

public class RoomItem : MonoBehaviour
{
    public TMP_Text RoomName;
    LobbyManager manager;

    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>();
    }
    public void CreateRoom(string _Name)
    {
        RoomName.text = _Name;
    }
    public void OnClickItem()
    {
        manager.JoinRoom(RoomName.text);
    }
}

