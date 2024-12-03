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
    public bool isGameActive = true;
    public bool waveRunning = true;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI breakText;
    public float waveTime = 10.0f;
    public float breakTime = 7.0f;
    public float timerActive = 10;
    public float breakTimer = 6;
    private int spawnDelay = 1;
    private float spawnInterval = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        while(waveRunning == true) 
        {
        WaveTimer();
        InvokeRepeating("SpawnAsteroids", spawnDelay, spawnInterval);
        if(timerActive <= 0)
        {
        waveRunning = false;
        BreakTimer();
        
        }

        if(breakTimer <= 0)
        {
        waveRunning = true;
        WaveTimer();

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
        float x = Random.Range(-12.5f, 12.5f);
        float y = .1f;  
        float z = 8;  

        return new Vector3(x, y, z);
    }

    public void WaveTimer()
    {
            waveTime -= Time.deltaTime;
            timerActive = Mathf.FloorToInt(waveTime);
            timerText.text = "Wave timer: " + timerActive;
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0;
    }

    public void BreakTimer()
    {
            breakTime -= Time.deltaTime;
            breakTimer = Mathf.FloorToInt(breakTime);
            timerText.text = "Break timer: " + breakTimer;
    }
}
