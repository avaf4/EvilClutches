using UnityEngine;

public class fireball_movement : MonoBehaviour
{
    public float speed = 0.005f;
    public float MaxX = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector2.right);

        // if we are at the end of the screen, self-destruct
        if (transform.position.x > MaxX)
        {
            Destroy(gameObject);
        }
    }
}
