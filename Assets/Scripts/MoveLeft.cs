using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    float groundLength;
    float bgLength;

    BoxCollider2D groundCollider;
    SpriteRenderer backgroundRenderer;

    public float leftLimit;

    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            groundCollider = GetComponent<BoxCollider2D>();
            groundLength = groundCollider.size.x;
           // Debug.Log("gr length: " + groundLength);
        }
        if (gameObject.CompareTag("bgg"))
        {
            backgroundRenderer = GetComponent<SpriteRenderer>();
            bgLength = backgroundRenderer.size.x;
           // Debug.Log("bg length: "+bgLength);
        }

    }

    
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundLength)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundLength, transform.position.y);
            }
        }
        if (gameObject.CompareTag("bgg"))
        {
            if (transform.position.x <= -bgLength)
            {
                transform.position = new Vector2(transform.position.x + 2 * bgLength, transform.position.y);
            }
        }

        if (gameObject.CompareTag("Column"))
        {
            if (transform.position.x <= leftLimit)
            {
                Destroy(gameObject);
            }
        }

        
    }
}
