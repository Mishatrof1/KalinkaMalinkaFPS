using UnityEngine;

namespace Project
{
    public class DamageObject : MonoBehaviour
    {
        public ShellData ShellData;

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable == null)
                return;

            damageable.Damage(ShellData.Damage);

            Destroy(gameObject);
        }
    }
}
