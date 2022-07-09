using Photon.Pun;
using UnityEngine;

namespace Project
{
    public class Destroyer : MonoBehaviour
    {
        public void Destroy()
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
