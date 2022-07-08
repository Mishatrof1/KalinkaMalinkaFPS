using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using StarterAssets;
public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Transform[] spawnPos;

    private void Start()
    {
        int rand = Random.Range(0, spawnPos.Length);
        Transform spawnPoint = spawnPos[rand];
        GameObject Player =  PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity);
        PlayerConfig playerAvatar = Player.GetComponent<PlayerConfig>();
        RPC_ShowAvatar(playerAvatar);
    }

    [PunRPC]
    void RPC_ShowAvatar(PlayerConfig config)
    {
        config.SkinnedMeshRenderer.sharedMesh = config.Avatars[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
    }
}

