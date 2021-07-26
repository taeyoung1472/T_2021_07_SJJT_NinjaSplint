using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed;
    private bool isGround;
    private int jumpCount;
    private Rigidbody2D rigidbody;
    private float hp;
    [SerializeField]
    private float basicHp;
    [SerializeField]
    private Slider hpSlider;
    private Animator animator = null;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumpCount = 0;
        hp = basicHp;
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true;
            animator.Play("Playermove");
            jumpCount = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Object")
        {
            hp--;
            UpdateUi();
        }
        if(collision.transform.tag == "Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
            UpdateUi();
        }
    }
    private void Update()
    {
        if (isGround == true)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigidbody.AddForce(Vector2.up * jumpSpeed);
                        animator.Play("jump2");
                    jumpCount--;
                    if (jumpCount == 1)
                    {
                    animator.Play("jump");
                        
                    }
                }
            }
        }
       
        if (transform.position.y > 3)
        {
            transform.position = new Vector2(-6, 3);

        }
    }
    void UpdateUi()
    {
        hpSlider.value = hp / basicHp;
    }
}
