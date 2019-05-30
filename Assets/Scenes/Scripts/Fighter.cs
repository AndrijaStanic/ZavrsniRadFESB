using System;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat
{
    
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] Weapon defaultWeapon = null;
        [SerializeField] Transform handTransform = null;

        Weapon currentWeapon = null;
        PlayerHealthBar playerHealthBar;
        Transform target;
        AudioSource audioSource;
        float timeSinceLastAttack = 0;

        private void Start() {
            EquipWeapon(defaultWeapon);
            audioSource = GetComponent<AudioSource>();
            playerHealthBar = GetComponent<PlayerHealthBar>();
        }

        

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

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(handTransform, animator);
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > currentWeapon.timeBetweenAttacks)
            {
                // print("Vrijeme je: " + currentWeapon.timeBetweenAttacks);
                // ovo triggera Ht Event
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
            FriendlyTree fTree = target.GetComponent<FriendlyTree>();
            PlantingPlace plantingPlace = target.GetComponent<PlantingPlace>();
            if (health != null)
            {
                PlayChopAS();
                //print("ulazim u enemy tree"); testing
                DealDamageToEnemyTree(health);

            }
            else if(fTree != null)
            {
                PlayChopAS();
                //print("ulazim u friendly tree"); testing
                DealDamageToFriendlyTree(fTree);
            }
            else if(plantingPlace != null)
            {
                //print(" ulazim u planting place"); testing
                DealDamageToPlantingPlace(plantingPlace);
            }
            


        }

        private void PlayChopAS()
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        private void DealDamageToEnemyTree(Tree health)
        {
            health.TakeDamage(currentWeapon.GetDamage());
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeDamage(currentWeapon.GetDamage());
            if (health.health <= 0)
            {
                Cancel();
            }
        }

        private void DealDamageToFriendlyTree(FriendlyTree fTree)
        {
            //FriendlyTree fTree = target.GetComponent<FriendlyTree>();
            fTree.TakeDamage(currentWeapon.GetDamage());
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeDamage(currentWeapon.GetDamage());
            if (fTree.health <= 0)
            {
                Cancel();
            }
        }

        private void DealDamageToPlantingPlace(PlantingPlace plantingPlace)
        {
            plantingPlace.TakeDamage(currentWeapon.GetDamage());
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeDamagePlant(currentWeapon.GetDamage(), playerHealthBar.isAvailableForPlanting);
            if (plantingPlace.health <= 0)
            {
                Cancel();
            }
        }

        private bool CalculateRange()
        {
            return Vector3.Distance(transform.position, target.position) < currentWeapon.GetRange();
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }


        public void Cancel()
        {
            //audioSource.Stop();
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
