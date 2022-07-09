using UnityEngine;

namespace Project.Enemies
{
    public class GoblinAttack : MonoBehaviour
    {
        public bool CanAttack { get; set; }

        [SerializeField]
        private GoblinData _goblinData;

        [SerializeField]
        private AttackTrigger _attackTrigger;

        public void TryAttack()
        {
            _attackTrigger.Enable();
        }

        private void Awake()
        {
            _attackTrigger.Disable();

            _attackTrigger.OnTrigger += OnTrigger;
        }

        private void OnTrigger(IDamageable damageable)
        {
            damageable.Damage(_goblinData.Damage);
        }
    }
}
