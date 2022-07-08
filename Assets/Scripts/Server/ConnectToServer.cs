using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Project
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        public TMP_InputField NicknameField;
        public void OnClickConnect()
        {
            if (NicknameField.text.Length <= 4) return;
            
            PhotonNetwork.NickName = NicknameField.text;
            Debug.Log("Connecting");
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

        }

        public override void OnConnectedToMaster()
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
