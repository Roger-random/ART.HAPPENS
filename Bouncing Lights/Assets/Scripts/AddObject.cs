using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddObject : MonoBehaviour
{
    public GameObject objectToAdd;
    public float timeIntervalMin;
    public float timeIntervalMax;
    public float timeToFirstAdd;

    private float timeSeconds;
    private float timeLastGen;

    // Start is called before the first frame update
    void Start()
    {
        timeSeconds = 0;
        timeLastGen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSeconds += Time.deltaTime;

        if (timeSeconds > timeToFirstAdd)
        {
            if (Keyboard.current.spaceKey.isPressed &&
                timeSeconds > timeLastGen + timeIntervalMin)
            {
                // Add if space is down, with minimum time between adds.
                Add();
            }
            else if (timeSeconds > timeLastGen + timeIntervalMax)
            {
                // If no lights were added within maximum interval, add one.
                Add();
            }
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
