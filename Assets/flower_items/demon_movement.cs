using UnityEngine;

public class demon_movement : MonoBehaviour
{
    public float speed = 0.005f;
    public float MaxX = 8;
    public GameObject DemonCryPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Vector2.right);

        // if we are at the end of the screen, self-destruct
        if (transform.position.x < -MaxX)
        {
            Destroy(gameObject);
        }
    }
    // when demon interacts with other object, instantiate the demon cry and destory the demon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            Instantiate(DemonCryPrefab);
            Destroy(gameObject);
        }
    }
}