using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using ExitGames.Client.Photon;

namespace Project
{
    public class PlayerItem : MonoBehaviourPunCallbacks
    {
        public TMP_Text PlayerName;
        public Color highlightColor;
        public GameObject LeftArrowBtn;
        public GameObject RightArrowBtn;

        ExitGames.Client.Photon.Hashtable playerProp =
            new ExitGames.Client.Photon.Hashtable();

        public Image PlayerAvatar;
        public Sprite[] avatars;

        Player player;

        public void SetName(Player _player)
        {
            PlayerName.text = _player.NickName;
            player = _player;
            UpdatePlayerItem(player);
        }

        public void ApplyChanges()
        {
            LeftArrowBtn.SetActive(true);
            RightArrowBtn.SetActive(true);
        }

        public void OnClickLeftArrow()
        {
            if ((int)playerProp["playerAvatar"] == 0)
            {
                playerProp["playerAvatar"] = avatars.Length - 1;
            }
            else
            {
                playerProp["playerAvatar"] = (int)playerProp["playerAvatar"] - 1;
            }
            PhotonNetwork.SetPlayerCustomProperties(playerProp);
        }
        public void OnClickRightArrow()
        {
            if ((int)playerProp["playerAvatar"] == avatars.Length - 1)
            {
                playerProp["playerAvatar"] = 0;
            }
            else
            {
                playerProp["playerAvatar"] = (int)playerProp["playerAvatar"] + 1;
            }
            PhotonNetwork.SetPlayerCustomProperties(playerProp);
        }


        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
           if(player == targetPlayer)
           {
                UpdatePlayerItem(targetPlayer);
           }
        }

        void UpdatePlayerItem(Player player)
        {
            if (player.CustomProperties.ContainsKey("playerAvatar"))
            {
                PlayerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
                playerProp["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
            }
            else
            {
                playerProp["playerAvatar"] = 0;
            }
        }
    }
}
