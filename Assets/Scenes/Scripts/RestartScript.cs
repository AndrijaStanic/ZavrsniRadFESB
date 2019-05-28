using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    
    public void Click()
    {
        FriendlyTree.treesCreated = 0;
        Tree.treesCreated = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
    }
}
