using Photon.Pun;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(Rigidbody))]
    public class PS : Shell
    {
        private Rigidbody _rigidbody;
        private Vector3 _lastPosition;

        protected override void OnInitialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = transform.forward * ShellData.MoveSpeed;
            _lastPosition = transform.position;
        }

        protected override void OnFixedUpdate()
        {
            if (Physics.Linecast(_lastPosition, transform.position, out RaycastHit hit))
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();

                if (damageable != null)
                    damageable.Damage(ShellData.Damage);

                PhotonNetwork.Destroy(gameObject);
            }

            _lastPosition = transform.position;
        }
    }
}
