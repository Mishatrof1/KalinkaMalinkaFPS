using UnityEngine;

namespace Project
{
    public abstract class Shell : MonoBehaviour
    {
        public ShellData ShellData;

        protected virtual void OnUpdate()
        {
            
        }

        private void Update()
        {
            OnUpdate();
        }
    }
}
