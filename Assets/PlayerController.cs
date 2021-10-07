using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject planet = null;
    public GameObject bullet = null;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(planet.transform.position, Vector3.forward, 50 * Time.deltaTime);
        BulletFiring();
    }

    private void BulletFiring()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject clone = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
            clone.GetComponent<Bullet>().manager = manager;
            Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
            cloneRb.velocity = transform.TransformDirection(Vector2.up * 10);
        }
    } 
}
