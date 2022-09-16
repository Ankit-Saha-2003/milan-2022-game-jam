using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public bool isChasing;
    public float stoppingDistance;
    public float retreatDistance;

    public float cooldown;
    float countdown;

    public Transform target;
    public GameObject bullet;

    Rigidbody2D rb;
    Vector2 movement;
    Vector3 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        countdown = cooldown;
    }   

    // Update is called once per frame
    void Update()
    {
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        if (isChasing) {
            Vector2 lookDir = target.position - transform.position;
            float rotAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rot;
        }

        if (countdown > 0)
            countdown -= Time.deltaTime;
    }

    void FixedUpdate() 
    {
            if (isChasing) {
                MoveCharacter(movement);
                Shoot();
            }
    }

    void MoveCharacter(Vector2 dir) 
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance) 
            rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime)); 
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance) 
            rb.MovePosition((Vector2)transform.position - (dir * speed * Time.deltaTime)); 
    }

    void Shoot()
    {
        if (countdown <= 0) {
            Instantiate(bullet, transform.position, Quaternion.identity);
            countdown = cooldown;
        }
    }
}
