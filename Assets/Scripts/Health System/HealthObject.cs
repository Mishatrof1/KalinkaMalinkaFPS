using UnityEngine;
using UnityEngine.Events;

namespace Project
{
    public class HealthObject : MonoBehaviour, IDamageable, IFillable
    {
        public bool RefreshOnAwake = true;
        public int Health;
        public UnityEvent OnDie;

        private int _startHealth;

        public void Refresh()
        {
            _startHealth = Health;
        }

        public void Damage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;

            CheckDie();
        }

        public void Fill(int health)
        {
            int newHealth = Health + health;

            if (newHealth > _startHealth)
                newHealth = _startHealth;

            Health = newHealth;
        }

        private void Awake()
        {
            if (RefreshOnAwake)
                Refresh();
        }

        private void CheckDie()
        {
            if (Health == 0)
                Die();
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
    }
}
