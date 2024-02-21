using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;

    [SerializeField] private float limitLeft = -842f;
    [SerializeField] private float limitRight = 842f;

    private Rigidbody2D rb;
    private Vector2 lastTouchPosition;

    private bool isDragging = false;
    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (Input.touchCount > 0 && canMove)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    lastTouchPosition = touch.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector2 delta = touch.position - lastTouchPosition;
                        transform.Translate(delta.x * moveSpeed * Time.deltaTime, 0, 0);
                        float clampedX = Mathf.Clamp(transform.position.x, limitLeft, limitRight);
                        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
                        lastTouchPosition = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.gravityScale = 20f;
                    canMove = false;
                    break;
            }
        }
    }
}
