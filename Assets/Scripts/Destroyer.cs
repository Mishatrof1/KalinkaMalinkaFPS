using Photon.Pun;
using System.Collections;
using UnityEngine;

namespace Project
{
    public class Destroyer : MonoBehaviour
    {
        public float Time;

        public void Destroy()
        {
            if (Time == 0f)
                PhotonDestroy();
            else
                StartCoroutine(DestroyCoroutine());
        }

        private void PhotonDestroy()
        {
            PhotonNetwork.Destroy(gameObject);
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(Time);

            PhotonDestroy();
        }
    }
}
