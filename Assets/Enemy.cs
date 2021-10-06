using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject planet;

    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.Find("Planet");
        transform.LookAt(planet.transform, Vector3.back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
