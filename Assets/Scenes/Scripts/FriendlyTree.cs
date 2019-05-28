using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;



public class FriendlyTree : MonoBehaviour
{
    
    [SerializeField] GameObject thisStump;
    [SerializeField] float waitingTimeInSec = 4f;
    public static int treesCreated = 0;

    public Transform spawnPoint;
    public float health = 20f;

    AudioSource audioSource;
    GameObject thisTree;
    PlayerHealthBar phb;
    Player player;
    private bool isFallen = false;
    int i = 0;
    
    private void Start()
    {
        treesCreated++;
        audioSource = GetComponent<AudioSource>();
        thisTree = transform.parent.gameObject;
        phb = FindObjectOfType<PlayerHealthBar>();
        player = FindObjectOfType<Player>();
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
            PlayFallingAS();
            StartCoroutine(destroyTree()); // zove unsti stablo
            isFallen = true; // state = fallen
        }
    }

    private void PlayFallingAS()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private IEnumerator destroyTree()
    {
        phb.friendlyTreesCut++;
        treesCreated--;
        player.SitDownGetMeTwenty(20f); // skida 20 healtha jer si glup
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
        if (health <= 0)
        { // provjerava ima li healtha
            GetComponent<Mover>().Cancel(); // cancela target
        }

        health -= damage; // skida hp ovisno o damagu
    }
    
}