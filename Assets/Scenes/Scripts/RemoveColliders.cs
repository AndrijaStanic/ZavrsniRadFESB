using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveColliders : MonoBehaviour
{
    public GameObject words;
    private void OnTriggerEnter(Collider other) {
        print("collided");
        words.SetActive(false);
    }
}
