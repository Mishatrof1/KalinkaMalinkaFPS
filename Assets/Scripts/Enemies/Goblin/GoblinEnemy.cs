using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Enemies
{
    public class GoblinEnemy : Enemy<GoblinData>
    {
        public EnemyState CurrentEnemyState { get; set; }

        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private AudioSource _audioSource;
        private HealthObject _healthObject;
        private GoblinAttack _goblinAttack;

        private EnemyState _lastEnemyState;
        private Transform _target;

        public void SimulateDeath(DamageEventData eventData)
        {
            CurrentEnemyState = EnemyState.Death;

            Rigidbody rigidbody = eventData.Collider?.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddForceAtPosition(eventData.Velocity / 30f, eventData.FromPosition, ForceMode.Impulse);
        }

        protected override void OnInitialize()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _healthObject = GetComponentInChildren<HealthObject>();
            _goblinAttack = GetComponent<GoblinAttack>();

            _navMeshAgent.speed = EnemyData.MoveSpeed;

            _healthObject.Refresh();

            StartCoroutine(RefreshTargetCoroutine());
        }

        protected override void OnUpdate()
        {
            RefreshCurrentEnemyState();
            CheckEnemyState();
            RefreshLastEnemyState();
        }

        private IEnumerator RefreshTargetCoroutine()
        {
            WaitForSeconds wait = new WaitForSeconds(0.15f);

            while (true)
            {
                _target = Players.Instance.GetNearestPlayer(transform.position).Transform;

                if (_target == null)
                {
                    yield return wait;

                    continue;
                }

                _navMeshAgent.SetDestination(_target.position);

                yield return wait;
            }
        }

        private void RefreshCurrentEnemyState()
        {
            if (CurrentEnemyState == EnemyState.Death)
                return;

            if (CanAttack())
                CurrentEnemyState = EnemyState.Attack;
            else
                CurrentEnemyState = EnemyState.Move;
        }

        private void CheckEnemyState()
        {
            if (CurrentEnemyState == EnemyState.Death)
                Die();
            else if (CurrentEnemyState == EnemyState.Move)
                Move();
            else if (CurrentEnemyState == EnemyState.Attack)
                Attack();
        }

        private void RefreshLastEnemyState()
        {
            _lastEnemyState = CurrentEnemyState;
        }

        private bool CanAttack()
        {
            if (_target == null)
                return false;

            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance > EnemyData.AttackDistance)
                return false;

            return true;
        }

        private void Move()
        {
            _animator.SetTrigger("Move");
        }

        private void Attack()
        {
            _animator.SetTrigger("Attack");

            transform.LookAt(_target);
        }

        private void Die()
        {
            enabled = false;

            _goblinAttack.enabled = false;
            _healthObject.enabled = false;
            _navMeshAgent.enabled = false;

            StopAllCoroutines();

            _animator.enabled = false;
            _audioSource.PlayOneShot(EnemyData.DeathSounds[Random.Range(0, EnemyData.DeathSounds.Length)]);
        }

        public enum EnemyState
        {
            None,
            Move,
            Attack,
            Death
        }
    }
}
