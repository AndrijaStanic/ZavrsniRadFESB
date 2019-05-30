using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] GameObject itemPickup = null;
    PlayerHealthBar pHealthBar;

    public SphereCollider rend2;

    private float timer = 0;
    private float timerMax = 0;

    void Start()
    {
        pHealthBar = FindObjectOfType<PlayerHealthBar>();
        //rend2 = GetComponent<SphereCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pHealthBar.seedsCollected++;
            Destroy(itemPickup);
            pHealthBar.seedsCollectedPanel.SetActive(true);
            Invoke("Waiterino", 3f);
            //StartCoroutine(Wait());
            //Destroy(this);
            
        }
    }
    
    private void Waiterino()
    {
        pHealthBar.seedsCollectedPanel.SetActive(false);
        rend2.enabled = false;
    }
    private IEnumerator Wait()
    {
        rend2.enabled = false;
        yield return new WaitForSeconds(2f);
        pHealthBar.seedsCollectedPanel.SetActive(false);
        
    }
}
