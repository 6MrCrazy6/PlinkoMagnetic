using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelMagnet : MonoBehaviour
{
    public float magnetForce = 30000f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 1f;
                Vector2 repelForce = new Vector2(magnetForce, 2f); 
                rb.AddForce(repelForce * Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {

                rb.gravityScale = 20f;
            }
        }
    }
}
