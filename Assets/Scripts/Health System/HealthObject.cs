using UnityEngine;

namespace Project
{
    public class HealthObject : MonoBehaviour, IDamageable, IFillable
    {
        public int Health;

        private int _startHealth;

        public void Damage(int damage)
        {
            Health -= damage;
        }

        public void Fill(int health)
        {

        }

        private void Start()
        {
            _startHealth = Health;
        }
    }
}
