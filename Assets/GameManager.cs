using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Camera mainCamera = null;
    public GameObject enemy = null;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.orthographicSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
    }
    
    void CameraZoom()
    {
        if(mainCamera.orthographicSize < 5)
        {
            mainCamera.orthographicSize += Time.deltaTime;
        }
        else
        {
            StartCoroutine("SpawnEnemy");
        }
    }

    IEnumerator SpawnEnemy()
    {
        Debug.Log("Spawned Enemy");
        yield return new WaitForSeconds(5f);
    }
}
