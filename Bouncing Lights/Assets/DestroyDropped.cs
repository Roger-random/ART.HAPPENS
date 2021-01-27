using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDropped : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
