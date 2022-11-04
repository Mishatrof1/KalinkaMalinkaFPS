using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace Project
{

    public abstract class Gun : MonoBehaviourPunCallbacks
    {
        public GunData GunData;
        public Transform ShellSpawnPoint;
        public AudioSource AudioSourcePlayer;
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

        protected abstract bool Aim();

        protected abstract void Shoot();
        protected abstract void RPC_PlayShootSound();
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
