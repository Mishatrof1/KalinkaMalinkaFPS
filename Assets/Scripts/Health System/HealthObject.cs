using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project
{
    public class HealthObject : MonoBehaviour
    {
        public bool RefreshOnAwake = true;
        public DeathEvent OnDie;

        private HealthPart[] _healthParts;

        public void Refresh()
        {
            _healthParts = GetComponentsInChildren<HealthPart>();

            for (int i = 0; i < _healthParts.Length; i++)
                _healthParts[i].Refresh();
        }

        public void DistributeDamage(DamageEventData eventData)
        {
            List<HealthPart> healthParts = GetWholeHealthParts();
            int averageDamage = (int)(eventData.Damage / 100f * 70f);

            if (averageDamage == 0)
                averageDamage = 1;

            for (int i = 0; i < healthParts.Count; i++)
                healthParts[i].DistributedDamage(averageDamage);

            for (int i = 0; i < healthParts.Count; i++)
                healthParts[i].ReceivedDistributedDamage = false;
        }

        public void Die(DamageEventData eventData)
        {
            OnDie?.Invoke(eventData);
        }

        private void Awake()
        {
            if (RefreshOnAwake)
                Refresh();
        }

        private List<HealthPart> GetWholeHealthParts()
        {
            List<HealthPart> healthParts = new List<HealthPart>();

            for (int i = 0; i < _healthParts.Length; i++)
            {
                HealthPart healthPart = _healthParts[i];

                if (!healthPart.IsDied)
                    healthParts.Add(healthPart);
            }

            return healthParts;
        }

        [Serializable]
        public class DeathEvent : UnityEvent<DamageEventData> { }
    }
}
