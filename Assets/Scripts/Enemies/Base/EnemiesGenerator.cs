using System.Collections;
using UnityEngine;
using Photon.Pun;

namespace Project.Enemies
{
    public class EnemiesGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _prefabs;

        [SerializeField]
        private Transform[] _spawns;

        private void Start()
        {
            StartCoroutine(GenerateEnemiesCoroutine());
        }

        private IEnumerator GenerateEnemiesCoroutine()
        {
            yield return new WaitForSeconds(1f);

            for (int i = 0; i < 100; i++)
            {
                GenerateEnemy();

                yield return new WaitForSeconds(1f);
            }
        }

        private void GenerateEnemy()
        {
            GameObject prefab = GetPrefab();
            Vector3 spawn = GetSpawn();
            Quaternion rotation = Quaternion.identity;

            PhotonNetwork.Instantiate(prefab.name, spawn, rotation);
        }

        private GameObject GetPrefab()
        {
            return _prefabs[Random.Range(0, _prefabs.Length)];
        }

        private Vector3 GetSpawn()
        {
            return _spawns[Random.Range(0, _spawns.Length)].position;
        }
    }
}
