using System;
using UnityEngine;

namespace Project
{
    public class AttackTrigger : MonoBehaviour
    {
        public event Action<IDamageable> OnTrigger;

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

            OnTrigger?.Invoke(damageable);

            Disable();
        }
    }
}
