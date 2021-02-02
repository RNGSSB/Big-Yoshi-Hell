using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float lifetime;
    public int damage;
    public bool isPlayerBullet;
    public bool hasExplosion = false;
    public GameObject explosion;
    private Transform pos;
    public bool KeepGoingAfterKill;
    public bool up;
    public bool right;
    public bool left;
    private float hitlag;
    public float hitlagmul = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        CheckDir(1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        

        }
    }

    void CheckDir(float mul)
    {
        if (up)
        {
            rb.velocity = transform.up * speed * mul;
        }
        else if (right)
        {
            rb.velocity = transform.right * speed * mul;
        }
        else if (left)
        {
            rb.velocity = -transform.right * speed * mul;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitlag = 0.06f * hitlagmul;
        enemyscript enemy = collision.gameObject.GetComponent<enemyscript>();
        PlayerControls player = collision.gameObject.GetComponent<PlayerControls>();
        if (enemy != null && isPlayerBullet)
        {
            enemy.GetHurt(damage, hitlag);
            CheckForExplosion();
            if (KeepGoingAfterKill && enemy.health <= 0)
            {
                hitlag *= 1.2f;
                damage += 1;
                CheckDir(1.2f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (player != null && !isPlayerBullet)
        {
            player.TakeDamage(damage);
            CheckForExplosion();
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }

    private void CheckForExplosion()
    {
        if (hasExplosion)
        {
            Instantiate(explosion, pos.position, pos.rotation);
        }
        else
        {
            return;
        }
    }
}
