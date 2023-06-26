using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject Rock1;
    public GameObject Rock2;
    public GameObject Rock3;
    public GameObject Rock4;
    public GameObject Rock5;
    public GameObject enemy;
    public Vector3 spawnValues;
    public int RockdCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int enemynum;
    public int Round = 5;
    private int CurrentRound = 1;

    public Text scoreText;
    public Text roundText;
    private int score;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        score = 0;
        scoreText.text = "Score: " + score;
        roundText.enabled = true;
        roundText.text = "Round " + CurrentRound;
        enemynum = Random.Range(1, 6);
    }
    void Update() 
    { 

    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (CurrentRound <= Round)
            {
                for (int i = 0; i < RockdCount; i++)
                 {
                    if (CurrentRound == 1)
                    {
                        switch (enemynum)
                        {
                            case 1:
                                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                Quaternion spawnRotation = Quaternion.identity;
                                Instantiate(Rock1, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 6);
                                break;
                            case 2:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock2, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 6);
                                break;
                            case 3:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock3, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 6);
                                break;
                            case 4:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock4, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 6);
                                break;
                            case 5:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock5, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 6);
                                break;
                            default:
                                break;
                        }
                    }
                    
                    else if (CurrentRound > 1 && CurrentRound <= 3)
                    {
                        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                        Quaternion spawnRotation = Quaternion.identity;
                        Instantiate(enemy, spawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }

                    else if (CurrentRound > 3)
                    {
                        switch (enemynum)
                        {
                            case 1:
                                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                Quaternion spawnRotation = Quaternion.identity;
                                Instantiate(Rock1, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 7);
                                break;
                            case 2:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock2, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 7);
                                break;
                            case 3:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock3, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 7);
                                break;
                            case 4:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock4, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 7);
                                break;
                            case 5:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(Rock5, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 7);
                                break;
                            case 6:
                                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                                spawnRotation = Quaternion.identity;
                                Instantiate(enemy, spawnPosition, spawnRotation);
                                yield return new WaitForSeconds(spawnWait);
                                enemynum = Random.Range(1, 7);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(waveWait);
            CurrentRound++;
            roundText.text = "Round " + CurrentRound;

        }
    }
}