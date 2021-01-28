using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionFly : MonoBehaviour
{
    public float waitTimeBeforeFlight;

    public float flightDuration;

    public Vector3 endPosition;

    private float elapsedTime = 0;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > waitTimeBeforeFlight)
        {
            transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, flightDuration);

            // Destroy self once close enough to end position
            if (Vector3.Distance(transform.position, endPosition) < 0.001f)
            {
                Object.Destroy(gameObject);
            }
        }
    }
}
