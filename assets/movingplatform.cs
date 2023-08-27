using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float jumpHeight = 30f;
    public bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.gravityScale = 3;
        if (right)
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemystop"))
        {
            right = false;
        }
        else if (collision.gameObject.CompareTag("enemycon"))
        {
            right = true;
        }
    }
}
