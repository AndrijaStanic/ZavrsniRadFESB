using System;
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapons", order = 0)]
    public class Weapon : ScriptableObject {

        
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float weaponRange = 2f;

        public float timeBetweenAttacks = 1f;

        const string weaponName = "Weapon";


        public void Spawn(Transform handTransform, Animator animator)
        {
            DestroyOldWeapon(handTransform);

            if (weaponPrefab != null)
            {
                GameObject weapon = Instantiate(weaponPrefab, handTransform);
                weapon.name = weaponName;
            }
            var overrideController = animator.runtimeAnimatorController 
                    as AnimatorOverrideController;
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
            else if (overrideController != null)
            {
                animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
            }
            
        }

        private void DestroyOldWeapon(Transform handTransform)
        {
            Transform oldWeapon = handTransform.Find(weaponName);
            if (oldWeapon == null)
            {
                return;
            }
            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }

        public float GetDamage()
        {
            return weaponDamage;
        }
        public float GetRange()
        {
            return weaponRange;
        }


    }
}