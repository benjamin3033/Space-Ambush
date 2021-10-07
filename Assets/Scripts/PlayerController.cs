using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject planet = null;
    public GameObject bullet = null;
    public GameManager manager;
    float timer = 0.35f;

    bool canFire = true;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(planet.transform.position, Vector3.forward, 50 * Time.deltaTime);
        BulletFiring();
    }

    private void BulletFiring()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canFire == true)
        {
            canFire = false;
            GameObject clone = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
            clone.GetComponent<Bullet>().manager = manager;
            Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
            cloneRb.velocity = transform.TransformDirection(Vector2.up * 10);
            
        }
        else if(!canFire)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 0.35f;
                canFire = true;
            }
        }
    } 
}
