using System;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace Project
{
    public class Kalak : Gun
    {
        private bool _canShoot = true;
        private int _currentAmmo;
        private int _totalAmmo;
        private Quaternion IdentityRot;
        protected override void OnInitialize()
        {
            _currentAmmo = GunData.MaxTurnAmmo;
            _totalAmmo = GunData.MaxTotalAmmo;
            AudioSourcePlayer = GetComponent<AudioSource>();
            IdentityRot = transform.localRotation;
            UpdateGun();
        }
       
        protected override void OnUpdate()
        {
                LookToTarget();

            if (Input.GetMouseButton(0))
                Shoot();
        }
        
        protected override void LookToTarget()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Vector3 target;

            if (Physics.Raycast(ray, out RaycastHit hit))
                target = hit.point;
            else
                target = ray.GetPoint(GunData.ShootRange);

            transform.LookAt(target);
        }

        protected override bool CanShoot()
        {
            return _canShoot;
        }
        protected override bool Aim()
        {
            if (Input.GetMouseButton(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Shoot()
        {
            if (!Aim()) return;
            if (!CanShoot()) return;

            _canShoot = false;
             RPC_Shoot();
             RPC_PlayShootSound();
            _currentAmmo--;
            UpdateGun();

            if (CheckReload())
                return;

            UpdateShootRate();
        }
        [PunRPC]
        protected override void RPC_PlayShootSound()
        {
            AudioSourcePlayer.PlayOneShot(GunData.ShootSound);
        }
        [PunRPC]
        public void RPC_Shoot()
        {
            PhotonNetwork.Instantiate(GunData.AvailableShells[0].name, ShellSpawnPoint.position, ShellSpawnPoint.rotation);
        }

     
        private bool CheckReload()
        {
            if (_currentAmmo > 0)
                return false;

            Reload();

            return true;
        }

        private async void UpdateShootRate()
        {
            await Task.Delay(TimeSpan.FromSeconds(GunData.ShootRate));

            _canShoot = true;
        }

        private async void Reload()
        {
            _canShoot = false;

            if (_totalAmmo == 0)
                return;

            await Task.Delay(TimeSpan.FromSeconds(GunData.ReloadRate));

            if (GunData.MaxTurnAmmo > _totalAmmo)
                _currentAmmo = _totalAmmo;
            else
                _currentAmmo = GunData.MaxTurnAmmo;

            _totalAmmo -= _currentAmmo;

            _canShoot = true;

            UpdateGun();
        }

        private void UpdateGun()
        {
            CurrentGunUpdatedEvent updatedEvent = new CurrentGunUpdatedEvent(
                GunData.MaxTurnAmmo,
                _currentAmmo,
                _totalAmmo
                );

            EventBus.Instance.Send(updatedEvent);
        }

      
    }
}
