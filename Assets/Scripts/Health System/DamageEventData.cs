using UnityEngine;

namespace Project
{
    public struct DamageEventData
    {
        public int Damage { get; }
        public Vector3 Velocity { get; }
        public Vector3 FromPosition { get; }
        public Collider Collider { get; }

        public DamageEventData(int damage, Vector3 velocity, Vector3 fromPosition, Collider rigidbody)
        {
            Damage = damage;
            Velocity = velocity;
            FromPosition = fromPosition;
            Collider = rigidbody;
        }
    }
}
