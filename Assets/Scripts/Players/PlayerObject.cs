using UnityEngine;

namespace Project
{
    public class PlayerObject : MonoBehaviour, IPlayerObject
    {
        public Transform Transform => transform;

        private void Start()
        {
            Players.Instance.AddPlayerObject(this);
        }

        private void OnDestroy()
        {
            Players.Instance.RemovePlayerObject(this);
        }
    }
}
