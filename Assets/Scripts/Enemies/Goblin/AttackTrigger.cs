using System;
using UnityEngine;

namespace Project
{
    public class AttackTrigger : MonoBehaviour
    {
        public event Action<IDamageable, Collider> OnTrigger;

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable == null)
            {
                Disable();

                return;
            }

            Disable();

            OnTrigger?.Invoke(damageable, other);
        }
    }
}
