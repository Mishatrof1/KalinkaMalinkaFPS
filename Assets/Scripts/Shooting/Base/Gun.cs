using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Project
{
    public abstract class Gun : MonoBehaviour
    {
        public GunData GunData;
        public Transform ShellSpawnPoint;

        private bool _canShoot = true;

        protected virtual void OnInitialize()
        {

        }

        protected virtual void OnUpdate()
        {
            LookToTarget();

            if (Input.GetMouseButton(0))
                Shoot();
        }

        protected virtual void LookToTarget()
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Vector3 target;

            Debug.DrawRay(ray.origin, ray.direction, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit))
                target = hit.point;
            else
                target = ray.GetPoint(GunData.ShootRange);

            transform.LookAt(target);
        }

        protected virtual bool CanShoot()
        {
            return _canShoot;
        }

        protected virtual void Shoot()
        {
            if (!CanShoot())
                return;

            _canShoot = false;

            Instantiate(GunData.AvailableShells[0].Prefab, ShellSpawnPoint.position, ShellSpawnPoint.rotation);
            AudioSource.PlayClipAtPoint(GunData.ShootSound, transform.position);

            Aaa();
        }

        private async void Aaa()
        {
            await Task.Delay(TimeSpan.FromSeconds(GunData.ShootRate));

            _canShoot = true;
        }

        private void Update()
        {
            OnUpdate();
        }
    }
}
