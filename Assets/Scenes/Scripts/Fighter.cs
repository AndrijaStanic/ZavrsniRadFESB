using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    [RequireComponent(typeof(Mover))]
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponRange = 2f;
        Transform target;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!CalculateRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //ovo triggera Ht Event
                TriggerAttack();
                timeSinceLastAttack = 0;

            }

        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("StopAttack");
            GetComponent<Animator>().SetTrigger("Attack");
        }

        // Animation event
        void Hit()
        {
            Tree health = target.GetComponent<Tree>();
            health.TakeDamage(weaponDamage);
            if (health.health <= 0)
            {
                Cancel();
            }

        }

        private bool CalculateRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }


        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("Attack");
            GetComponent<Animator>().SetTrigger("StopAttack");
        }
    }
}
