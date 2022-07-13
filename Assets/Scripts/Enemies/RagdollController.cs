using UnityEngine;

namespace Project
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField]
        private bool _disableOnAwake = true;

        [SerializeField]
        private Collider[] _colliders;

        private Rigidbody[] _rigidbodies;

        public void Enable()
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                _colliders[i].isTrigger = false;
                //_colliders[i].enabled = true;
            }

            for (int i = 0; i < _rigidbodies.Length; i++)
                _rigidbodies[i].isKinematic = false;
        }

        public void Disable()
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                _colliders[i].isTrigger = true;
                //_colliders[i].enabled = false;
            }

            for (int i = 0; i < _rigidbodies.Length; i++)
                _rigidbodies[i].isKinematic = true;
        }

        private void Awake()
        {
            _rigidbodies = new Rigidbody[_colliders.Length];

            for (int i = 0; i < _colliders.Length; i++)
                _rigidbodies[i] = _colliders[i].GetComponent<Rigidbody>();

            if (_disableOnAwake)
                Disable();
        }
    }
}
