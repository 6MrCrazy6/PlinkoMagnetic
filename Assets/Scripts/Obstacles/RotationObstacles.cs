using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstacles : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = rotationSpeed;
    }
}
