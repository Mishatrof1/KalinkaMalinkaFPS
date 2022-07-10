using UnityEngine;

namespace Project
{
    [CreateAssetMenu]
    public class HealthPartData : ScriptableObject
    {
        public HealthPartType HealthPartType;
        public int Health;
    }
}
