using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;



public class Tree : MonoBehaviour
{
    [SerializeField] GameObject itemPickup = null;
    [SerializeField] GameObject thisStump = null;
    [SerializeField] float waitingTimeInSec = 4f;
    public float health = 20f;
    public Transform spawnPoint;

    private bool isFallen = false;
    public static int treesCreated = 0;
    GameObject thisTree;
    AudioSource audioSource;
    PlayerHealthBar phb;
    private void Start()
    {
        treesCreated++;
        audioSource = GetComponent<AudioSource>();
        thisTree = transform.parent.gameObject;
        phb = FindObjectOfType<PlayerHealthBar>();

    }

    private void Update()
    {
        CheckIfTreeIsDead();
    }

    private void CheckIfTreeIsDead()
    {
        if (health <= 0 && isFallen == false)
        {

            Rigidbody rigidBody = thisTree.AddComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            // rigidBody.detectCollisions = false; propada korz zemlju /ignora collision
            rigidBody.useGravity = true;
            rigidBody.mass = 5;
            rigidBody.AddTorque(Vector3.forward, ForceMode.Impulse); // gurni naprid
            PlayAS();
            StartCoroutine(destroyTree()); // zove unsti stablo
            isFallen = true; // state = fallen
        }
    }

    private void PlayAS()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private IEnumerator destroyTree()
    {
        phb.driedTreesCut++;
        treesCreated--;
        yield return new WaitForSeconds(waitingTimeInSec); // ceka vrime u sekundama
        Destroy(thisTree); // unisti stablo
        PlaceStump(); // zove stavi stup
        itemPickup.SetActive(true);
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