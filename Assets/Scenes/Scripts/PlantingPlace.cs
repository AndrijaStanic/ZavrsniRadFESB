using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingPlace : MonoBehaviour
{
    [SerializeField] GameObject itemToBeDestroyed = null;
    [SerializeField] GameObject treeForPlanting = null;
    [SerializeField] float waitingTimeInSec = 3f;

    public float health = 5f;
    public Transform spawnPoint = null;


    public static int treesPlantedLeft = 0;

    private bool isPlanted = false;

    GameObject thisPod;
    AudioSource audioSource;
    PlayerHealthBar playerHealthBar;

    private void Start()
    {
        treesPlantedLeft++;
        audioSource = GetComponent<AudioSource>();
        thisPod = transform.parent.gameObject;
        playerHealthBar = FindObjectOfType<PlayerHealthBar>();
    }

    private void Update()
    {
        if (health <= 0 && !isPlanted)
        CheckIfPodIsDead();
    }
    private void CheckIfPodIsDead()
    {
        PlayAS();
        StartCoroutine(DestroyPod());
    }
    private void PlayAS()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private IEnumerator DestroyPod()
    {
        if (health <= 0 && isPlanted == false)
        {
            playerHealthBar.treesPlanted++;
            treesPlantedLeft--;
            playerHealthBar.seedsCollected--;
            PlaceTree();  // zove stavi stablo
            Destroy(thisPod); // unisti pod 
            isPlanted = true;
            yield return new WaitForSeconds(waitingTimeInSec);
            
        }
    }

    private void PlaceTree() //metoda za postavljanje stumpa
    {
        Instantiate(treeForPlanting, spawnPoint.position, spawnPoint.rotation); // postavlja stump na tu lokaciju
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0)
        { // provjerava ima li healtha
            GetComponent<Mover>().Cancel(); // cancela target
        }
        if (playerHealthBar.isAvailableForPlanting)
        health -= damage; // skida hp ovisno o damagu
    }

}
