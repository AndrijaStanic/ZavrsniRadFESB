using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void Click()
    {
        FriendlyTree.treesCreated = 0;
        Tree.treesCreated = 0;
        player.isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
    }
}
