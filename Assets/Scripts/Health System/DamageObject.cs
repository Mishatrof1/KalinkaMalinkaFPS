using System;
using UnityEngine;
using UnityEngine.Events;

namespace Project
{
    public class DamageObject : MonoBehaviour
    {
        public ShellData ShellData;
        public DamageEvent OnDamage;

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable == null)
                return;

            damageable.Damage(ShellData.Damage);

            OnDamage?.Invoke(ShellData.Damage);
        }

        [Serializable]
        public class DamageEvent : UnityEvent<int> { }
    }
}
