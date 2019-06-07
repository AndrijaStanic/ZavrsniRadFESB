using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float timeBetweenHPDrops = 1f;
    [SerializeField] float maxHealthPoints = 100f;
    public float currentHealthPoints = 300;

    public bool isDead = false;
    
    float timeSinceLastHPDrop = 0;

    PlayerHealthBar phb;
    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
        
    }

    private void Start()
    {
        phb = GetComponent<PlayerHealthBar>();
    }
    private void Update()
    {
        timeSinceLastHPDrop += Time.deltaTime;
        if (!isDead)
        {
            Die();
            TakeDamage();
        }
        
    }
    
    private void Die()
    {
        if (currentHealthPoints <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("Death");
            //Destroy(this);

        }
    }
    public void TakeDamage()
    {

        if ((healthAsPercentage > 0) && isDead == false)
        {
            if (timeSinceLastHPDrop > timeBetweenHPDrops)
            {
                currentHealthPoints--;
                timeSinceLastHPDrop = 0;
            }
        }
    }
    public void SitDownGetMeTwenty(float f)
    {
        currentHealthPoints = currentHealthPoints - f;
    }
   
}

