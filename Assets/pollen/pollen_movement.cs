using UnityEngine;

public class pollen_movement : MonoBehaviour
{
    public float speed = 4f;
    public float MaxY = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector2.up * Time.deltaTime);

        // if we are at the end of the screen, self-destruct
        if (transform.position.y > MaxY)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sunflower"))
        {
            Destroy(gameObject);
        }
    }

}
