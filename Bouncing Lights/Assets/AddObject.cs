using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public GameObject objectToAdd;
    public float timeInterval;

    private float timeSeconds;
    private float timeLastGen;

    // Start is called before the first frame update
    void Start()
    {
        timeSeconds = 0;
        timeLastGen = 0;
        Add();
    }

    // Update is called once per frame
    void Update()
    {
        timeSeconds += Time.deltaTime;

        if (timeSeconds > timeLastGen + timeInterval)
        {
            Add();
        }
    }

    public void Add()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-9f, 9f),
            7f,
            Random.Range(-9f, 9f));

        Instantiate(objectToAdd, randomPosition, Quaternion.identity);

        timeLastGen = timeSeconds;
    }
}
