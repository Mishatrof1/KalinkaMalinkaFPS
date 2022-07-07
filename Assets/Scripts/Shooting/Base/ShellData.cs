using UnityEngine;

namespace Project
{
    public abstract class ShellData : ScriptableObject
    {
        public GameObject Prefab;
        public int Damage;
        public float MoveSpeed;
    }
}
