using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager manager;
    public GameObject explosion = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            manager.score++;
            Instantiate(explosion, transform.position, transform.rotation);
            DestroyEnemy(collision);
        }
    }

    void DestroyEnemy(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject, 1);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
