using UnityEngine;

namespace Project
{
    public class HealthPart : MonoBehaviour, IDamageable
    {
        public HealthPartData HealthPartData => _healthPartData;
        public int Health { get; private set; }
        public bool IsDied { get; private set; }
        public bool ReceivedDistributedDamage { get; set; }

        [SerializeField]
        private HealthPartData _healthPartData;

        private HealthObject _healthObject;

        private DamageEventData _damageEventData;

        public void Damage(DamageEventData eventData)
        {
            _damageEventData = eventData;
            Health -= _damageEventData.Damage;

            if (Health < 0)
                Health = 0;

            CheckDeath();
        }

        public void DistributedDamage(int damage)
        {
            if (ReceivedDistributedDamage)
                return;

            ReceivedDistributedDamage = true;
            Health -= damage;

            if (Health < 0)
                Health = 0;

            CheckDeath();
        }

        public void Refresh()
        {
            Health = _healthPartData.Health;
        }

        private void Awake()
        {
            _healthObject = GetComponentInParent<HealthObject>();

            if (_healthObject.RefreshOnAwake)
                Refresh();
        }

        private void CheckDeath()
        {
            if (IsDied)
                return;

            if (Health > 0)
                return;

            if (_healthPartData.HealthPartType == HealthPartType.Lethal)
            {
                _healthObject.Die(_damageEventData);

                IsDied = true;
            }
            else if (_healthPartData.HealthPartType == HealthPartType.Nonlethal)
            {
                if (!ReceivedDistributedDamage)
                    _healthObject.DistributeDamage(_damageEventData);
            }
        }
    }
}
