using System;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    
    public class PlayerController : MonoBehaviour {
        Player player;

        private void Start()
        {
            player = GetComponent<Player>();
        }

        private void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            //CheckHp();
        }

        private bool InteractWithCombat()
            {
                RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
                foreach (RaycastHit hit in hits) //za svaki hit u hits radi:
                {
                    CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                    if (target == null) continue; //ako je null idi dalje, ako nije stani

                    if (Input.GetMouseButtonDown(1) && player.isDead == false) // kad kliknes i ako nije mrtav idi
                    {
                        GetComponent<Fighter>().Attack(target);
                    }
                    return true;
                }
                return false;
            }

            private bool InteractWithMovement()
            {
                RaycastHit hit;
                bool hasHit = Physics.Raycast(GetMouseRay(), out hit); //ako je mis kliknut stavi true i koordinate u hit
                if (hasHit) //kliknuto = true
                {
                    if (Input.GetMouseButtonDown(1) && player.isDead == false)
                    {
                        GetComponent<Mover>().StartMoveAction(hit.point); //idi do vektora di je kliknut mis
                    }
                    return true;
                }
                return false;
            }

            private static Ray GetMouseRay() //vraca poziciju klika misa
            {
                return Camera.main.ScreenPointToRay(Input.mousePosition);
            }
            private void CheckHp()
            {
                if (player.isDead)
                {
                Destroy(this);
            }
            }
        }

    }

