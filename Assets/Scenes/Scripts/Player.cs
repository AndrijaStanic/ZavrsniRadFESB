using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float timeBetweenHPDrops = 1f;
    float timeSinceLastHPDrop = 0;
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
        TakeDamage();
    }
    public void TakeDamage()
    {
        if (healthAsPercentage > 0)
        {
            if (timeSinceLastHPDrop > timeBetweenHPDrops)
            {
                currentHealthPoints--;
                timeSinceLastHPDrop = 0;
            }
        }
    }
}
