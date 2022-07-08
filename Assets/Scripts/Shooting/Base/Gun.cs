using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace Project
{
    public abstract class Gun : MonoBehaviourPunCallbacks
    {
        public GunData GunData;
        public Transform ShellSpawnPoint;

        protected virtual void OnInitialize()
        {

        }

        protected virtual void OnUpdate()
        {
            
        }

        protected virtual void LookToTarget()
        {
            
        }

        protected virtual bool CanShoot()
        {
            return true;
        }

        protected virtual void Shoot()
        {
            
        }

        private void CheckReload()
        {

        }

        private void Update()
        {
            OnUpdate();
        }

        private void Start()
        {
            OnInitialize();
        }
    }
}
