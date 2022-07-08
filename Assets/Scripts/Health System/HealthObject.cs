using UnityEngine;

namespace Project
{
    public class HealthObject : MonoBehaviour, IDamageable, IFillable
    {
        public bool RefreshOnAwake = true;
        public int Health;

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

            CheckDeath();
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

        private void CheckDeath()
        {
            if (Health == 0)
                Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
