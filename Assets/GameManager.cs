using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
