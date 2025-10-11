using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text TxtScore;
    static public int Score;
    public int currentScore;
    public GameObject FlowerPrefab;

    public float MaxX = 8f;
    public float MaxY = 3f;

    float ySpawn;
    float futureTime;
    float randomTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("spawnFlowers", 1);

        ySpawn = Random.Range(-MaxY, MaxY);

        futureTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        randomTime = Random.Range(1f, 4f);
        if (Time.time > futureTime)
        {
            spawnFlowers();
            futureTime = Time.time + randomTime;
        }
        // currentScore = Score;
        TxtScore.text = "Score:" + Score;
    }
    private void spawnFlowers()
    {
        transform.position = new Vector3(10f, ySpawn, 0f);
        Instantiate(FlowerPrefab, transform.position, Quaternion.identity);
    }
}
