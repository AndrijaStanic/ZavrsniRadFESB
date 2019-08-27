using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    Player player;
    PlayerHealthBar phb;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        phb = FindObjectOfType<PlayerHealthBar>();
        
    }
    public void Click()
    {
        FriendlyTree.treesCreated = 0;
        Tree.treesCreatedAll = 0;
        Tree.treesCreated = 0;
        PlantingPlace.treesPlantedLeft = 0;
        phb.seedsCollected = 0;
        phb.isAvailableForPlanting = false;
        phb.allEnemyTrees = 0;
        player.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
    }
    
}
