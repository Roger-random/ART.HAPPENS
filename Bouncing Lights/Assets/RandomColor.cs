using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Light lt = GetComponent<Light>();

        lt.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
