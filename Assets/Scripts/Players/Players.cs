using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Players : MonoBehaviour
    {
        public static Players Instance { get; private set; }

        private readonly List<IPlayerObject> _playerObjects = new List<IPlayerObject>();

        public void AddPlayerObject(IPlayerObject playerObject)
        {
            _playerObjects.Add(playerObject);
        }

        public bool RemovePlayerObject(IPlayerObject playerObject)
        {
            return _playerObjects.Remove(playerObject);
        }

        public void ClearPlayerObjects()
        {
            _playerObjects.Clear();
        }

        public IPlayerObject GetNearestPlayer(Vector3 fromPosition)
        {
            if (_playerObjects.Count == 0)
                throw new System.Exception("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA NOT PLAYERS");

            IPlayerObject lastPlayerObject = _playerObjects[0];
            float lastDistance = Vector3.Distance(fromPosition, lastPlayerObject.Transform.position);

            for (int i = 0; i < _playerObjects.Count; i++)
            {
                IPlayerObject playerObject = _playerObjects[i];
                float distance = Vector3.Distance(fromPosition, playerObject.Transform.position);

                if (distance < lastDistance)
                {
                    lastDistance = distance;
                    lastPlayerObject = playerObject;
                }
            }

            return lastPlayerObject;
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}
