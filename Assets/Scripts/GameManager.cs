using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Camera mainCamera = null;
    public GameObject enemy = null;
    public GameObject planet = null;
    public GameObject player = null;
    public GameObject explosion = null;
    public Text scoreText = null;

    public int health = 3;
    public int score = 0;
    bool doneZoom = false;
    float delay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.orthographicSize = 0.01f;
        Cursor.lockState = CursorLockMode.Locked;        
    }

    // Update is called once per frame
    void Update()
    {
        if(planet == null)
        {
            Debug.Log("Planet Gone");
        }
        else
        {
            PlanetLife();
        }
        CameraZoom();
        Score();
        if(doneZoom)
        {
            SpawnEnemy();
        }
    }

    void PlanetLife()
    {
        Renderer planetColor = planet.gameObject.GetComponent<Renderer>();
        switch (health)
        {
            case -1:
                EndStart();
                break;
            case 0:
                planetColor.material.color = new Color(1f, 0, 0);
                break;

            case 1:
                planetColor.material.color = new Color(1f, 0.4f, 0.4f);
                break;

            case 2:
                planetColor.material.color = new Color(1f, 0.7f, 0.7f);
                break;
        }
    }

    private void EndStart()
    {
        GameObject clone = Instantiate(explosion);
        clone.transform.localScale = new Vector3(5, 5, 5);
        Destroy(player);
        Destroy(planet);
        StartCoroutine("EndRound");
    }

    IEnumerator EndRound()
    {
        yield return new WaitForSeconds(3f);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
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
            delay = 3f;
        }
    }
   
}
