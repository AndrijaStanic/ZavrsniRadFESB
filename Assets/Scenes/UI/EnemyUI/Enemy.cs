using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float maxHealthPoints = 20f;
    public float currentHealthPoints = 20f;
    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }

    }
    private void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealthPoints -= damage; // skida hp ovisno o damagu
    }
    public void TakeDamagePlant(float damage, bool isAvailable)
    {   
        if (isAvailable)
        currentHealthPoints -= damage; // skida hp ovisno o damagu
    }

}
