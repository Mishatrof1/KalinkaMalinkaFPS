using UnityEngine;

namespace Project
{
    public abstract class Shell : MonoBehaviour
    {
        public ShellData ShellData;

        private float _currentLifetime;

        protected virtual void OnUpdate()
        {
            CheckLifetime();
        }

        protected virtual void CheckLifetime()
        {
            _currentLifetime += Time.deltaTime;

            if (_currentLifetime >= ShellData.Lifetime)
                Destroy(gameObject);
        }

        private void Update()
        {
            OnUpdate();
        }
    }
}
