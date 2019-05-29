using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] GameObject itemPickup = null;
    PlayerHealthBar pHealthBar;

    private float timer = 0;
    private float timerMax = 0;
    // Start is called before the first frame update
    void Start()
    {
        pHealthBar = FindObjectOfType<PlayerHealthBar>();   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pHealthBar.seedsCollected++;
            Destroy(itemPickup);
            pHealthBar.seedsCollectedPanel.SetActive(true);
            Invoke("Waiterino", 3f);
            //Destroy(this);
            
        }
    }
    
    private void Waiterino()
    {
        pHealthBar.seedsCollectedPanel.SetActive(false);
    }
}
