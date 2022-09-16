using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public EnemyAI ai;

    Vector2 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        targetVector = new Vector2(ai.target.position.x, ai.target.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
        if (transform.position.x == targetVector.x && transform.position.y == targetVector.y)
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
