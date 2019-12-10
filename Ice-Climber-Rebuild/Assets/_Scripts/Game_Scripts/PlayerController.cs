using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
 
    //Inspector variables
    [SerializeField] private int carrots = 0;
    [SerializeField] private TextMeshProUGUI carrotText;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private LayerMask ground;

    private enum State {idle, speed, jumping, falling }
    private State state = State.idle;
      

    public float maxSpeed = 8f;
    public float speed = 5f;
    public float jumpPower = 2f;

    public bool grounded;
    private bool jump;
    private bool doubleJump;
    private bool attack;

    public GameObject gameOverText, restartButton;

    Rigidbody2D rb2D;
    private Animator anim;
    private Collider2D coll;
    Collider2D collPj;
    public Collider2D collPjGround;



    void Start()
    {
        collPj = GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }

    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("Grounded", grounded);

        //Double Jump
        if (grounded)
        {
            doubleJump = true;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;

            } else if (doubleJump)
            {
                jump = true;
                doubleJump = false; 
            }
           
        }

        HandleInput();
        VelocityState();
        anim.SetInteger("state", (int)state); //Sets animation based on Enumerator State
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2D.velocity;

        fixedVelocity.x *= .75f;
        
        if(grounded)
        {
            rb2D.velocity = fixedVelocity; 
        }

        float h = CrossPlatformInputManager.GetAxis("Horizontal");

        rb2D.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2D.velocity.x, -maxSpeed, maxSpeed);
        rb2D.velocity = new Vector2(limitedSpeed, rb2D.velocity.y);

        if(h > .1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (h < -.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (jump)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
            state = State.jumping;
        }

        HandleAttacks();
        ResetValues();

    }
    
  

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Breakable"))
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            Destroy(col.gameObject);
            MuertePj();  
        } 
    }
    void MuertePj()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.AddForce(Vector2.up * 2.5f,ForceMode2D.Impulse);
        collPj.enabled = false;
        collPjGround.enabled = false;
        Destroy(this.gameObject,1f);
    }
    public void EnemyDestroy()
    {

        rb2D.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
    }
 
    private void HandleAttacks()
    {
        if (attack)
        {
            anim.SetTrigger("Attack");
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true;
        }
    }

    private void ResetValues()
    {
        attack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            carrots += 1;
            carrotText.text = carrots.ToString();
        }
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {
            if(rb2D.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (grounded == true)
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb2D.velocity.x) > 1f)
        {
            state = State.speed;
        }
        else
        {
            state = State.idle;
        }
    }

   
}
