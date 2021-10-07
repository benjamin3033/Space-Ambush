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
        Cursor.lockState = CursorLockMode.Locked;
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
            int locationZone = Random.Range(1, 4);
            float chosenMinX = 0;
            float chosenMaxX = 0;
            float chosenMinY = 0;
            float chosenMaxY = 0;

            switch (locationZone)
            {
                case 1:
                    chosenMinX = -8.566362f;
                    chosenMaxX = 8.566362f;
                    chosenMinY = 5.4f;
                    chosenMaxY = 5.4f;
                    break;

                case 2:
                    chosenMinX = -8.566362f;
                    chosenMaxX = 8.566362f;
                    chosenMinY = -5.4f;
                    chosenMaxY = -5.4f;
                    break;

                case 3:
                    chosenMinX = -9.28f;
                    chosenMaxX = -9.28f;
                    chosenMinY = -4.7f;
                    chosenMaxY = 4.7f;
                    break;

                case 4:
                    chosenMinX = 9.28f;
                    chosenMaxX = 9.28f;
                    chosenMinY = -4.7f;
                    chosenMaxY = 4.7f;
                    break;
            }


            Instantiate(enemy, new Vector2(Random.Range(chosenMinX, chosenMaxX), Random.Range(chosenMinY, chosenMaxY)), Quaternion.identity);
            delay = 5f;
        }
    }
   
}
