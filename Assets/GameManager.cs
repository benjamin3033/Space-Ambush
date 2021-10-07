using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Camera mainCamera = null;
    public GameObject enemy = null;
    public Text scoreText = null;


    public int score = 0;
    bool doneZoom = false;
    float delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.orthographicSize = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
        CameraZoom();
        Score();
        if(doneZoom)
        {
            SpawnEnemy();
        }
    }

    void Score()
    {
        int finalScore = score * 100;
        scoreText.text = "" + finalScore;
    }
    
    void CameraZoom()
    {
        if(mainCamera.orthographicSize < 5)
        {
            mainCamera.orthographicSize += Time.deltaTime;
        }
        else
        {
            doneZoom = true;
        }
    }

    void SpawnEnemy()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            Instantiate(enemy);
            delay = 5f;
        }
    }
   
}
