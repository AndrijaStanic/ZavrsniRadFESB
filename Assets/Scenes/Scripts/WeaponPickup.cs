using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        Rigidbody _rb;
        [SerializeField] Weapon weapon = null;
        private void OnTriggerEnter(Collider other) {
            
            if (other.gameObject.tag == "Player")
            {
                print(" Colided!");
                other.GetComponent<Fighter>().EquipWeapon(weapon);
                //Destroy(this); onemogucava ponovo prikupljanje weapona!
            }
        }
    }

}