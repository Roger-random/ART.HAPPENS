using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextInstruction : MonoBehaviour
{
    public GameObject nextInstruction;

    private void Start()
    {
        TextMeshPro tmPro = GetComponent<TextMeshPro>();
        if (tmPro != null)
        {
            tmPro.color = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (nextInstruction != null)
        {
            nextInstruction.SetActive(true);
        }
    }

    void Update()
    {
        // Remove instructions once fallen
        if (gameObject.transform.position.y < -10f)
        {
            Object.Destroy(gameObject);
        }
    }
}
