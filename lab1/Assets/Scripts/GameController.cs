using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public int hazardCount;
    public GameObject hazard;
    public float spawnWait;
    public float waveWait;

    private int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWaves() { 
        while(true){
            for(int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-spawnValues.x, spawnValues.x),
                    spawnValues.y,
                    spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject asteroid = Instantiate(hazard, spawnPosition, spawnRotation);
                asteroid.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 10;
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int score) {
        totalScore += score;
        Debug.Log("Current Score: " + totalScore);
    }
}
