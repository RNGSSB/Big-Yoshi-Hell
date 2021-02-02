using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    
    public Transform point;
    public Transform missilepoint;
    public GameObject bullet;
    public GameObject missile;
    public GameObject smallCharge;
    public GameObject midCharge;
    public GameObject fullcharge;
    public GameObject explosion;
    private Rigidbody2D rb;
    private SpriteRenderer render;
    public int health = 3;
    public int missiles = 10;
    public float missilecooldown;
    private float nextmissile = 0;
    public float cooldown = 0.3f;
    private float nextfire = 0;
    public float chargetime;
    public float minchargetime;
    public float midchargetime;
    public float timecharged = 0;
    public float nextcharge;
    public float chargecooldown;

    public float speed = 0.09f;
    public float x;
    public float y;

    public Animator animator;
    public bool ischarge1 = false;
    public bool ischarge2 = false;
    public bool ischarge3 = false;

    private bool isdead = false;
    public int explosionumber = 1;
    public float deathtimer = 2f;

    //dash
    public int dashDirection;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public float dashCooldown;
    private float dashCool;

    //Knockback Stuff
    public float knockbackSpeed;
    private float invincibleTime;
    public float damageInvincibility;



    // Start is called before the first frame update
    void Start()
    {
        dashTime = startDashTime;
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (!isdead)
        {
            Shoot();
            Movement();
            ChargeShot();
            Dash();
           
        }
        DashInput();
        if (health > 3)
        {
            health = 3;

        }
        if (missiles > 5)
        {
            missiles = 5;

        }
        if (health <= 0)
        {
            isdead = true;
            deathtimer -= Time.deltaTime;
            if (deathtimer <= 0)
            {

                SceneManager.LoadScene("Title Screen");

            }
            if (explosionumber == 1)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                explosionumber--;
                
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }

        if(isdead == false)
        {

            ChargeAnimations();

        }

        

    }

    void Movement()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");


        //Vector2 move = new Vector2(x, y);
        Vector2 move = new Vector2(x, y);

        rb.velocity = move * speed;
        //transform.Translate(move * speed * Time.deltaTime);
    }

    void Shoot()
    {
        if(Time.time > nextfire)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Instantiate(bullet, point.position, point.rotation);
                
                nextfire = Time.time + cooldown;

            }

        }

        if (missiles > 0)
        {
            if(Time.time > nextmissile)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    Instantiate(missile, missilepoint.position, missilepoint.rotation);
                    nextmissile = Time.time + missilecooldown;

                    missiles--;


                }


            }

        }

        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {

            timecharged = Time.deltaTime + timecharged;
           
         }else if (timecharged > chargetime && Time.time > nextcharge)
        {
            timecharged = chargetime;

        }

        if (timecharged > chargetime)
        {
            timecharged = chargetime;

        }
      


    }


    void ChargeShot()
    {
        if (Input.GetButtonUp("Fire1") && timecharged == chargetime && timecharged > midchargetime && timecharged > minchargetime)
        {
            Instantiate(fullcharge, point.position, point.rotation);
            nextcharge = Time.deltaTime + chargecooldown;
           

        }

        if (Input.GetButtonUp("Fire1") && timecharged >= minchargetime && timecharged < midchargetime && timecharged < chargetime)
        {
            Instantiate(smallCharge, point.position, point.rotation);
            nextcharge = Time.deltaTime + chargecooldown;
           
        }
        if (Input.GetButtonUp("Fire1") && timecharged >= midchargetime && timecharged > minchargetime && timecharged < chargetime)
        {
            Instantiate(midCharge, point.position, point.rotation);
            nextcharge = Time.deltaTime + chargecooldown;
          
        }

        if (Input.GetButtonUp("Fire1"))
        {

            timecharged = 0;
            ischarge1 = false;
            ischarge2 = false;
            ischarge3 = false;
        }

        
    }
    void OnCollisionEnter2D(Collision2D transform)
    {
        if (transform.gameObject.CompareTag("Health"))
        {
            health = health + 1;

            Destroy(transform.gameObject);

        }
        if (transform.gameObject.CompareTag("Ammo"))
        {
            missiles = missiles + 3;
            Destroy(transform.gameObject);

        }

        if (transform.gameObject.CompareTag("Enemy"))
        {

            health = health - 1;

        }
        


    }

    public void DashInput(){

        

        if (x == 0 && y == 0)
        {
            dashDirection = 5;
        }else if (x == -1 && y == -1)
        {
            dashDirection = 1;
        }
        else if (x == 0 && y == -1)
        {
            dashDirection = 2;
        }
        else if (x == 1 && y == -1)
        {
            dashDirection = 3;
        }
        else if (x == -1 && y == 0)
        {
            dashDirection = 4;
        }
        else if (x == 1 && y == 0)
        {
            dashDirection = 6;
        }
        else if (x == -1 && y == 1)
        {
            dashDirection = 7;
        }
        else if (x == 0 && y == 1)
        {
            dashDirection = 8;
        }
        else if (x == 1 && y == 1)
        {
            dashDirection = 9;
        }
    }

    void Dash()
    {
        
        if (dashTime <= 0)
        {
            dashDirection = 5;
            dashTime = startDashTime;
            transform.Translate(Vector2.zero);
            render.color = new Color(255, 255, 255, 255);
            gameObject.layer = 9;
        }
        else
        {
                dashTime -= Time.deltaTime;
            if (Time.time > dashCool)
            {
                if (dashDirection == 5 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(Vector2.right * dashSpeed);
                    //transform.Translate(Vector2.right * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
                if (dashDirection == 6 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(Vector2.right * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
                else if (dashDirection == 4 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(-Vector2.right * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
                else if (dashDirection == 3 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(Vector2.right + -Vector2.up * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
                else if (dashDirection == 2 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(Vector2.down * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    gameObject.layer = 20;
                    render.color = Color.blue;
                }
                else if (dashDirection == 1 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(-Vector2.right + -Vector2.up * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
                else if (dashDirection == 7 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(-Vector2.right + Vector2.up * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
                else if (dashDirection == 8 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(Vector2.up * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
                else if (dashDirection == 9 && Input.GetButtonDown("Dash"))
                {
                    rb.AddForce(Vector2.right + Vector2.up * dashSpeed);
                    dashCool = dashCooldown + Time.time;
                    render.color = Color.blue;
                    gameObject.layer = 20;
                }
            }
            
        }

  

          
            
     




    }

    

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    
    void Knockback()
    {
 
    }
    void ChargeAnimations()
    {
        if(timecharged >= minchargetime && timecharged < midchargetime && timecharged < chargetime)
        {
            ischarge1 = true;
            ischarge2 = false;
            ischarge3 = false;

        }
        if (timecharged > minchargetime && timecharged >= midchargetime && timecharged < chargetime)
        {
            ischarge1 = false;
            ischarge2 = true;
            ischarge3 = false;

        }
        if (timecharged > minchargetime && timecharged > midchargetime && timecharged >= chargetime)
        {
            ischarge1 = false;
            ischarge2 = false;
            ischarge3 = true;

        }
        animator.SetBool("charge1", ischarge1);
        animator.SetBool("charge2", ischarge2);
        animator.SetBool("charge3", ischarge3);

    }
}
