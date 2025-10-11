using UnityEngine;

public class flower_movement : MonoBehaviour
{
    public float MinXSpeed = 1f;
    public float MaxXSpeed = 4f;

    public float MinYSpeed = -4f;

    public float MaxYSpeed = 4f;
    public float MaxX = 8f;
    public float MaxY = 3f;

    public GameObject FlowerPrefab;
    public GameObject FlowerPlopPrefab;

    float XSpeed;
    float YSpeed;
    float ySpawn;
    float futureTime;
    float randomTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XSpeed = Random.Range(MinXSpeed, MaxXSpeed);
        YSpeed = Random.Range(MinYSpeed, MaxYSpeed);

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
        // if we are at the end of the screen, self-destruct
        if (transform.position.x < -MaxX)
        {
            Destroy(FlowerPrefab);
        }
        if (transform.position.y > 5f)
        {
            Destroy(FlowerPrefab);
        }
        if (transform.position.y < -5f)
        {
            Destroy(FlowerPrefab);
        }
        transform.Translate(Vector2.left * Time.deltaTime * XSpeed + Vector2.up *Time.deltaTime * YSpeed);
    }
    // when demon interacts with other object, instantiate the demon cry and destory the demon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            Instantiate(FlowerPlopPrefab);
            Destroy(gameObject);
        }
    }

    private void spawnFlowers()
    {
        transform.position = new Vector3(10f, ySpawn, 0f);
        Instantiate(FlowerPrefab, transform.position, Quaternion.identity);
    }
}
