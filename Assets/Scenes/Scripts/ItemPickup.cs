﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] GameObject itemPickup = null;
    //[SerializeField] GameObject collider = null;
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
            rend2.isTrigger = false;
            Destroy(itemPickup);
            pHealthBar.seedsCollectedPanel.SetActive(true);
            //Destroy(rend2);
            Invoke("Waiterino", 3f);
            //StartCoroutine(Wait());
            
            
        }
    }
    
    private void Waiterino()
    {
        
        pHealthBar.seedsCollectedPanel.SetActive(false);
        
    }
    private IEnumerator Wait()
    {
        rend2.enabled = false;
        yield return new WaitForSeconds(2f);
        pHealthBar.seedsCollectedPanel.SetActive(false);
        
    }
}
