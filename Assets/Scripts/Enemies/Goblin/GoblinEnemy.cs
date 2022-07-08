using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Enemies
{
    public class GoblinEnemy : Enemy<GoblinData>
    {
        public EnemyState CurrentEnemyState { get; private set; }

        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private HealthObject _healthObject;

        private EnemyState _lastEnemyState;
        private Transform _target;

        protected override void OnInitialize()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _healthObject = GetComponentInChildren<HealthObject>();

            _navMeshAgent.speed = EnemyData.MoveSpeed;
            _healthObject.Health = EnemyData.Health;

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
            if (_lastEnemyState == CurrentEnemyState)
                return;

            if (CurrentEnemyState == EnemyState.Death)
            {

            }

            if (CurrentEnemyState == EnemyState.Attack)
                Attack();
        }

        private void RefreshLastEnemyState()
        {
            _lastEnemyState = CurrentEnemyState;
        }

        private bool CanAttack()
        {
            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance > EnemyData.AttackDistance)
                return false;

            return true;
        }

        private void Attack()
        {
            if (!CanAttack())
                return;
        }

        public enum EnemyState
        {
            Move,
            Attack,
            Death
        }
    }
}
