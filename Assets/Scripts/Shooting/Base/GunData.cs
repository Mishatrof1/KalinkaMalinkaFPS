using UnityEngine;

namespace Project
{
    public abstract class GunData : ScriptableObject
    {
        public ShellData[] AvailableShells;
        public float ShootRange;
        public float ShootRate;
        public float ReloadRate;
        public AudioClip ShootSound;
    }
}
