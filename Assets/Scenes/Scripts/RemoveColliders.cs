using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveColliders : MonoBehaviour
{
    [SerializeField]
    GameObject wordText = null;

    Camera cameraToLookAt;

    private void Start()
    {
        cameraToLookAt = Camera.main;
        SpawnText();
    }

    private void SpawnText()
    {
        Instantiate(wordText, transform.position, Quaternion.identity, transform);
        BoxCollider boxCollider = wordText.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.size.y.Equals(50);
    }

    private void OnTriggerEnter(Collider collider) {
        print("collided");
        wordText.SetActive(false);
    }
    void LateUpdate()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}
