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

            DamageEventData eventData = new DamageEventData(ShellData.Damage,
                Vector3.zero,
                transform.position,
                other);

            damageable.Damage(eventData);

            Destroy(gameObject);
        }
    }
}
