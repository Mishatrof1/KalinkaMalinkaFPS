using UnityEngine;

namespace Project.Enemies
{
    public abstract class Enemy<TEnemyData> : MonoBehaviour
    {
        public TEnemyData EnemyData;

        protected virtual void OnInitialize()
        {

        }

        protected virtual void OnUpdate()
        {

        }

        private void Start()
        {
            OnInitialize();
        }

        private void Update()
        {
            OnUpdate();
        }
    }
}
