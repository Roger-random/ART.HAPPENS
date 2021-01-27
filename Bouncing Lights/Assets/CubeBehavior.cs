using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddTorque(
            Random.Range(-10f,10f),
            Random.Range(-10f,10f),
            Random.Range(-10f,10f));
    }

    // Update is called once per frame
    void Update()
    {
        Transform objTransform = gameObject.transform;

        // Once we drop below -10, remove from scene.
        if (objTransform.position.y < -10)
        {
            Object.Destroy(gameObject);
        }
    }
}
