using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject planet;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.Find("Planet");
        RotateTowards(planet.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards(planet.transform.position);
    }

    void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void RotateTowards(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var offset = 90f;
        transform.rotation = Quaternion.Euler(Vector3.back * (angle + offset));
    }
}
