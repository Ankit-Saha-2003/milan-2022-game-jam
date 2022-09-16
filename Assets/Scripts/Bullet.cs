using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Transform player;
    float epsilon = 0.2f;

    Vector2 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetVector = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.position) < epsilon)
            DestroyBullet();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
            DestroyBullet();
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
