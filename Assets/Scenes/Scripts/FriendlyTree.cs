using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;



public class FriendlyTree : MonoBehaviour
{
    
    [SerializeField] GameObject thisStump;
    [SerializeField] float waitingTimeInSec = 4f;
    public Transform spawnPoint;
    public float health = 20f;
    private bool isFallen = false;
    AudioSource audioSource;
    GameObject thisTree;
    PlayerHealthBar phb;
    Player player;
    int i = 0;
    
    private void Start()
    {
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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            StartCoroutine(destroyTree()); // zove unsti stablo
            isFallen = true; // state = fallen
        }
    }

    private IEnumerator destroyTree()
    {
        phb.friendlyTreesCut++;
        player.SitDownGetMeTwenty(20f);
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