using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingRotation : MonoBehaviour
{
    public float minRotation = -40f;
    public float maxRotation = 40f;
    public float speedRotation = 42f;

    void Update()
    {
        float currentRotation = Mathf.PingPong(Time.time * speedRotation, maxRotation - minRotation) + minRotation;
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentRotation);
        transform.rotation = newRotation;
    }
}
