using UnityEngine;
using UnityEditor;

public class flower_movement : MonoBehaviour
{
    public float MinXSpeed = 1f;
    public float MaxXSpeed = 4f;

    public float MinYSpeed = -2f;

    public float MaxYSpeed = 2f;
    public float MaxX = 8f;
    public float MaxY = 3f;

    public GameObject FlowerPlopPrefab;

    float XSpeed;
    float YSpeed;
    bool isDestroyed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XSpeed = Random.Range(MinXSpeed, MaxXSpeed);
        YSpeed = Random.Range(MinYSpeed, MaxYSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // if we are at the end of the screen, self-destruct
        if (transform.position.x < -MaxX)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 5f)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * Time.deltaTime * XSpeed + Vector2.up *Time.deltaTime * YSpeed);
    }
    // when demon interacts with other object, instantiate the demon cry and destory the demon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pollen"))
        {
            Instantiate(FlowerPlopPrefab);
            Destroy(GameObject.FindWithTag("FlowerBarrier"));
            isDestroyed = true;
        }
        if (collision.CompareTag("Water")  && isDestroyed == true)
        {
            Instantiate(FlowerPlopPrefab);
            Destroy(GameObject.FindWithTag("Sunflower"));
            GameManager.Score += 10;
        }
    }
}
