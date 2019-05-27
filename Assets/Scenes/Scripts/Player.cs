using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float timeBetweenHPDrops = 1f;
    float timeSinceLastHPDrop = 0;
    public bool isDead = false;
    [SerializeField] float maxHealthPoints = 100f;
    [SerializeField] float currentHealthPoints = 300;
    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
        
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
    public void TakeDamage()
    {
        
        if ((healthAsPercentage > 0) && isDead == false )
        {
            if (timeSinceLastHPDrop > timeBetweenHPDrops)
            {
                currentHealthPoints--;
                timeSinceLastHPDrop = 0;
            }
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
}
