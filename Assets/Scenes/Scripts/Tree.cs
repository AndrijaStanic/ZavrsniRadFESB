using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;



public class Tree : MonoBehaviour
{
    public Transform spawnPoint;
    GameObject thisTree;
    [SerializeField] GameObject thisStump;
    private bool isFallen = false;
    [SerializeField] float fallingSpeed = 5f;
    public float health = 20f;
    private void Start()
    {
        thisTree = transform.parent.gameObject;
    }

    private void Update()
    {
        if (health <= 0 && isFallen == false)
        {
            
            Rigidbody rigidBody = thisTree.AddComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
            rigidBody.mass = 2;
            rigidBody.AddForce(Vector3.forward, ForceMode.Impulse);
            StartCoroutine(destroyTree());
            //OnDestroy();
            isFallen = true;
        }
    }

    private IEnumerator destroyTree()
    {
        yield return new WaitForSeconds(2f);
        Destroy(thisTree);
        Instantiate(thisStump, spawnPoint.position, spawnPoint.rotation);
    }
    public void TakeDamage(float damage)
    {
        if (health <= 0) {
            GetComponent<Mover>().Cancel();
        }

        health -= damage;
    }
    public void OnDestroy()
    {
        new WaitForSeconds(2f);
        Instantiate(thisStump, spawnPoint.position, spawnPoint.rotation);
    }


}