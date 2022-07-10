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

        private AudioSource _audioSource;

        public void TryAttack()
        {
            _attackTrigger.Enable();
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            _attackTrigger.Disable();

            _attackTrigger.OnTrigger += OnTrigger;
        }

        private void OnTrigger(IDamageable damageable)
        {
            damageable.Damage(_goblinData.Damage);

            AudioClip sound = GetAttackSound();

            _audioSource.PlayOneShot(sound);
        }

        private AudioClip GetAttackSound()
        {
            return _goblinData.AttackSounds[Random.Range(0, _goblinData.AttackSounds.Length)];
        }
    }
}
