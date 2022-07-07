using UnityEngine;

namespace Project
{
    public abstract class ShellData : ScriptableObject
    {
        public GameObject Prefab;
        public int Damage;
        public float MoveSpeed;
        public float Lifetime = 6f;
    }
}
