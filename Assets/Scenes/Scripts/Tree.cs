using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;



public class Tree : MonoBehaviour
{
    public Transform spawnPoint;
    GameObject thisTree;
    [SerializeField] GameObject thisStump;
    private bool isFallen = false;
    [SerializeField] float waitingTimeInSec = 4f;
    public float health = 20f;
    private void Start()
    {
        thisTree = transform.parent.gameObject;
    }

    private void Update()
    {
        if (health <= 0 && isFallen == false)
        {
            
            Rigidbody rigidBody = thisTree.AddComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            // rigidBody.detectCollisions = false; propada korz zemlju /ignora collision
            rigidBody.useGravity = true;
            rigidBody.mass = 5;
            rigidBody.AddTorque(Vector3.forward, ForceMode.Impulse); // gurni naprid
            StartCoroutine(destroyTree()); // zove unsti stablo
            isFallen = true; // state = fallen
        }
    }

    private IEnumerator destroyTree()
    {
        yield return new WaitForSeconds(waitingTimeInSec); // ceka vrime u sekundama
        Destroy(thisTree); // unisti stablo
        PlaceStump(); // zove stavi stup
    }

    private void PlaceStump() //metoda za postavljanje stumpa
    {
        Instantiate(thisStump, spawnPoint.position, spawnPoint.rotation); // postavlja stump na tu lokaciju
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0) { // provjerava ima li healtha
            GetComponent<Mover>().Cancel(); // cancela target
        }

        health -= damage; // skida hp ovisno o damagu
    }
}