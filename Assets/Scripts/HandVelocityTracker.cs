using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVelocityTracker : MonoBehaviour
{
    private Queue<Vector3> positionBuffer = new Queue<Vector3>();
    private Vector3 currentVelocity;
    private int bufferSize = 5; // Number of frames to average over

    void Start()
    {
        for (int i = 0; i < bufferSize; i++)
        {
            positionBuffer.Enqueue(transform.position);
        }
    }

    void Update()
    {
        // Update the position buffer
        if (positionBuffer.Count >= bufferSize)
        {
            positionBuffer.Dequeue();
        }
        positionBuffer.Enqueue(transform.position);

        // Calculate the average velocity over the buffer
        currentVelocity = CalculateAverageVelocity();
    }

    Vector3 CalculateAverageVelocity()
    {
        Vector3 sumOfVelocities = Vector3.zero;
        Vector3 previousPosition = positionBuffer.Peek();

        foreach (var position in positionBuffer)
        {
            Vector3 displacement = position - previousPosition;
            sumOfVelocities += displacement / Time.deltaTime;
            previousPosition = position;
        }

        return sumOfVelocities / positionBuffer.Count;
    }

    public float GetVelocityMagnitude()
    {
        return currentVelocity.magnitude;
    }
}
