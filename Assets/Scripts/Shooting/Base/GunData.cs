using UnityEngine;

namespace Project
{
    public abstract class GunData : ScriptableObject
    {
        public ShellData[] AvailableShells;
        public float ShootRange;
        public float ShootRate;
        public float ReloadRate;
        public int MaxTurnAmmo;
        public int MaxTotalAmmo;
        public AudioClip ShootSound;
    }
}
