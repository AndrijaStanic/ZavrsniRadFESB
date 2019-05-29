using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PlayerHealthBar : MonoBehaviour
{
    
    public int driedTreesCut; // posicena bolesna stabla
    public int friendlyTreesCut; // posicena zradva stabla
    public int seedsCollected; // koliko sjemena imamo
    public int treesPlanted; // koliko stabla smo planatali

    //public Text friendlyTreesSpawnedText; // testing

    public Text driedTreesCutText;
    public Text friendlyTreesCutText;
    public Text seedsCollectedText;
    public Text treesPlantedText;

    public Text gameOverTreesCutText;
    public Text gameOverTreesPlantedText;

    public Text gameSuccededTreesCutText;
    public Text gameSuccededTreesPlantedText;

    public Text seedsCollcetedText;

    public GameObject gameOverPanel;
    public GameObject UIItemsCollected_TimePanel;
    public GameObject HealthBarPanel;
    public GameObject HealthMaskPanel;
    public GameObject gameSuccededPanel;
    public GameObject seedsCollectedPanel;

    public bool isAvailableForPlanting = false;

    //AudioSource audioSource;
    RawImage healthBarRawImage;
    Player player;
    int treesSpawned; // spawnana stabla bolesna
    int friendlyTreesSpawned; // spawnana zdrava stabla

    int allEnemyTrees;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthBarRawImage = GetComponent<RawImage>();
        //audioSource = GetComponent<AudioSource>();
        friendlyTreesSpawned = FriendlyTree.treesCreated;
        //int allTrees = treesSpawned + friendlyTreesSpawned;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //friendlyTreesSpawnedText.text = "" + friendlyTreesSpawned;
        RefreshTreeNumbers();
        UpdateTreesCut();
        UpdateTreesPlanted();
        UpdateHealthBar();
        SetGameOverPanel();
        allEnemyTrees = Tree.treesCreatedAll;
        CheckIfPlayerIsAvailableForPlanting();
    }

    private void CheckIfPlayerIsAvailableForPlanting()
    {
        if (seedsCollected > 0)
        {
            isAvailableForPlanting = true;
        }
        else
            isAvailableForPlanting = false;
        //print(isAvailableForPlanting); //testing
    }

    private void RefreshTreeNumbers()
    {
        treesSpawned = Tree.treesCreated;
        friendlyTreesSpawned = FriendlyTree.treesCreated;
    }

    private void UpdateTreesPlanted()
    {
        seedsCollectedText.text = "Seeds collected: " + seedsCollected;
        treesPlantedText.text = "Trees planted: " + treesPlanted;
    }

    private void UpdateHealthBar()
    {
        float xValue = -(player.healthAsPercentage / 2f) - 0.5f;
        healthBarRawImage.uvRect = new Rect(xValue, 0f, 0.5f, 1f);
    }

    private void UpdateTreesCut()
    {
        driedTreesCutText.text = "Dried trees left: " + treesSpawned;
        friendlyTreesCutText.text = "Friendly trees left: " + friendlyTreesSpawned;
    }

    void SetGameOverPanel()
    {
        if (treesSpawned == 0 && treesPlanted == allEnemyTrees)
        {
            //audioSource.Play();
            gameSuccededPanel.SetActive(true);
            gameSuccededTreesCutText.text = "" + (friendlyTreesCut + driedTreesCut);
            gameSuccededTreesPlantedText.text = "" + treesPlanted;
            UIItemsCollected_TimePanel.SetActive(false);
            HealthBarPanel.SetActive(false);
            HealthMaskPanel.SetActive(false);
            player.isDead = true;
            return;
        }
        if (player.isDead)
        {
            
            gameOverPanel.SetActive(true);
            gameOverTreesCutText.text = "" + (friendlyTreesCut + driedTreesCut);
            gameOverTreesPlantedText.text = "" + treesPlanted;
            UIItemsCollected_TimePanel.SetActive(false);
            HealthBarPanel.SetActive(false);
            HealthMaskPanel.SetActive(false);
            
        }
        
    }
    private IEnumerator Wait()
    {
        print("usa u wait");
        yield return new WaitForSeconds(10f);
    }
}
