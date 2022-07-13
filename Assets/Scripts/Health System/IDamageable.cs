using UnityEngine;

namespace Project
{
    public interface IDamageable
    {
        void Damage(DamageEventData eventData);
    }
}
