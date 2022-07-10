using Photon.Pun;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(Rigidbody))]
    public class PS : Shell
    {
        private Rigidbody _rigidbody;
        private Vector3 _lastPosition;
        private int _layer;

        protected override void OnInitialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = transform.forward * ShellData.MoveSpeed;
            _lastPosition = transform.position;
            _layer = LayerMask.NameToLayer("Health Part");
        }

        protected override void OnFixedUpdate()
        {
            if (Physics.Linecast(_lastPosition, transform.position, out RaycastHit hit))
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    DamageEventData eventData = new DamageEventData(
                        ShellData.Damage,
                        _rigidbody.velocity,
                        _lastPosition,
                        hit.collider);

                    damageable.Damage(eventData);
                }

                PhotonNetwork.Destroy(gameObject);
            }

            _lastPosition = transform.position;
        }
    }
}
