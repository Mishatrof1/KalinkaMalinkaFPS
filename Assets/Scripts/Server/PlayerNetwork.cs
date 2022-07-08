using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace Project
{
    public class PlayerNetwork : MonoBehaviour
    {
        PhotonView photonView;
        public Behaviour[] behaviours;
        private void Awake()
        {
            photonView = GetComponent<PhotonView>();    
            if (!photonView.IsMine)
            {
                for (int i = 0; i < behaviours.Length; i++)
                {
                    behaviours[i].enabled = false;
                }
            }
        }
    }
}
