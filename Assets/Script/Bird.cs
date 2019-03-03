using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator ani;

    private bool isStarted;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        ani = this.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                ani.SetTrigger("flap");
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        ani.SetTrigger("die");
        GameControl.instance.BirdDied();

    }
}
