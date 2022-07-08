using UnityEngine;

namespace Project.Enemies
{
    [CreateAssetMenu]
    public class GoblinData : EnemyData
    {
        public float MoveSpeed;
        public int Health;
        public int Damage;
        public float AttackDistance;
    }
}
