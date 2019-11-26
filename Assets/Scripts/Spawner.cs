using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform spawnPoint;

    public float timeBetweenWave = 5.0f;
    public Text waveCountDownText;
    private float countdown = 2.0f;
    private int numberOfEnemies;

    void Start()
    {
        numberOfEnemies = 0;
    }
    void Update()
    {

        if (countdown <= 0.0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWave;
        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    public void setNumberOfEnemies(int enemyCount)
    {
        this.numberOfEnemies = enemyCount;
    }

    IEnumerator SpawnWave()
    {
        numberOfEnemies++;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        // GameObject enemy = Instantiate(enemies[0]);
        // enemy.transform.parent = transform;
        // enemy.transform.position = new Vector3(3, 0.5f, 3);
        // enemy.transform.Rotate(0.0f, 90.0f, 0.0f);
        Instantiate(enemies[0], spawnPoint.position, spawnPoint.rotation);
    }
}
