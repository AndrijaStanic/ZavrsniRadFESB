using UnityEngine;
using System.Collections;

public class CoinSpinner : MonoBehaviour
{

    public Transform target = null; // the object to rotate around
    [SerializeField] int speed = 50; // the speed of rotation

    void Start()
    {
        if (target == null)
        {
            target = gameObject.transform;
            Debug.Log("RotateAround target not specified. Defaulting to parent GameObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // RotateAround takes three arguments, first is the Vector to rotate around
        // second is a vector that axis to rotate around
        // third is the degrees to rotate, in this case the speed per second
        transform.RotateAround(target.transform.position, target.transform.forward, speed * Time.deltaTime);
    }
}
