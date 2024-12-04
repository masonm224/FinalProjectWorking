using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public GameObject Player;

    public bool isGameActive = true;
    public bool waveRunning = true;

    public TextMeshProUGUI EnemiesText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI UpgradeText;
    public TextMeshProUGUI titleScreenText;
    public TextMeshProUGUI GameOverDesc;
    public Button startButton;
    public Button restartButton;

    public float waveTime = 10.0f;
    public float timerActive = 10;
    public float breakTimer = 7.0f;
    private float enemiesPerWave = 3;
    private float waveNumber = 1;
    
    void Start()
    {
        isGameActive = true;
        titleScreenText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        
        EnemiesText.text = "Wave: " + waveNumber;
        if(waveNumber == 10)
        {
            GameOver();
        }
    }

    private IEnumerator SpawnWaves()
    {

    while(true) 
        {
        
            if(waveRunning == true)
            {
                
                for (int i = 0; i < enemiesPerWave; i++)
                    {
                        SpawnAsteroids();
                        yield return new WaitForSeconds(1f);
                    }
                    
                    yield return new WaitForSeconds(2.5f);
                    
                    enemiesPerWave += 2;
                    UpgradeText.gameObject.SetActive(true);
                    yield return new WaitForSeconds(7f);
                    UpgradeText.gameObject.SetActive(false);
                    waveNumber += 1;
                    
                    //TODO add a variable check if HP == 0 so the game will use break statement to end loop
            }
        }
    }

    void SpawnAsteroids()
    {
        int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
        Instantiate(asteroidPrefabs[asteroidIndex], GenerateRandomVector(), asteroidPrefabs[asteroidIndex].transform.rotation);
    }

    Vector3 GenerateRandomVector()
    {
        float x = Random.Range(-11.5f, 11.5f);
        float y = .1f;  
        float z = 8;  

        return new Vector3(x, y, z);
    }

    public void GameOver()
    {
        Player.gameObject.SetActive(false);
        isGameActive = false;
        GameOverText.gameObject.SetActive(true);
        GameOverDesc.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        waveNumber = 1;
    }

    public void RestartGame()
    {

     SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void BreakOpen()
    {
       UpgradeText.gameObject.SetActive(true);
    }

    public void BreakClose()
    {
       UpgradeText.gameObject.SetActive(false);
    }

    public void StartGame() 
    {
       EnemiesText.gameObject.SetActive(true);
       titleScreenText.gameObject.SetActive(false);
       startButton.gameObject.SetActive(false);
       Player.gameObject.SetActive(true);
       Time.timeScale = 1;
    }
  
}

