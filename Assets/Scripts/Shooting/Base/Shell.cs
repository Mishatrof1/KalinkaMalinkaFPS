using UnityEngine;

namespace Project
{
    public abstract class Shell : MonoBehaviour
    {
        public ShellData ShellData;

        private float _currentLifetime;

        protected virtual void OnUpdate()
        {
            
        }

        private void Update()
        {
            CheckLifetime();
            OnUpdate();
        }

        private void CheckLifetime()
        {
            _currentLifetime += Time.deltaTime;

            if (_currentLifetime >= ShellData.Lifetime)
                Destroy(gameObject);
        }
    }
}
