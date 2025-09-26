using Unity.VisualScripting;
using UnityEngine;

public class baby_movement : MonoBehaviour
{
    public float speed = 0.005f;
    public float MaxX = 8;

    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            //
            audioSource.Play();

            // 
            GetComponent<SpriteRenderer>().enabled = false;

            // terminate the baby
            Invoke("selfDestruct", 0.5f);
            // Debug.Log("I hit the fireball!");
        }
        if (collision.CompareTag("Player"))
        {
            Debug.Log("I hit the dragon");
        }
    }

    void selfDestruct()
    {
        Destroy(gameObject);
    }
}