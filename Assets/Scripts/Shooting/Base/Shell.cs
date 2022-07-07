using UnityEngine;

namespace Project
{
    public abstract class Shell : MonoBehaviour
    {
        public ShellData ShellData;

        private float _currentLifetime;

        protected virtual void OnInitialize()
        {

        }

        protected virtual void OnUpdate()
        {
            CheckLifetime();
        }

        protected virtual void OnFixedUpdate()
        {
            
        }

        protected virtual void CheckLifetime()
        {
            _currentLifetime += Time.deltaTime;

            if (_currentLifetime >= ShellData.Lifetime)
                Destroy(gameObject);
        }

        private void Awake()
        {
            OnInitialize();
        }

        private void Update()
        {
            OnUpdate();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
        }
    }
}
