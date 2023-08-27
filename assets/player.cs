using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float jumpHeight = 30f;
    public Transform real;
    //public GameObject panal;
    //public Text rText;
    private bool isGrounded = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //panal.SetActive(false);
        //rText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.gravityScale = 1;
        if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector2(speed * Time.deltaTime,0), ForceMode2D.Impulse);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("w") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpHeight * Time.deltaTime));
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpHeight * Time.deltaTime));
        }

        if (Input.GetKeyDown("s"))
        {
            rb.AddForce(new Vector2(0, -jumpHeight * Time.deltaTime));
        }
        if (Input.GetKeyDown("o"))
        {
            real.position = new Vector3(-9, -1, 0);
            rb.AddForce(new Vector2(0, -1000 * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            real.position = new Vector3(-9, -1, 0);
            rb.AddForce(new Vector2(0, -1000 * Time.deltaTime), ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

}
