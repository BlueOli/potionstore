using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Rotate(0f, 0f, -speed * Time.deltaTime );
    }
}
