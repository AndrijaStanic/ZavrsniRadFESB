using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void Click()
    {
        Debug.Log(" Restarting!");
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
        // Application.LoadLevel("ZavrsniRad");
    }
}
