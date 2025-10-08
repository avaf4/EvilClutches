using UnityEngine;

public class bee_movement : MonoBehaviour
{
    public float speed = 0.005f;
    public float MaxX = 6;
    private float x;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");

        if (transform.position.x >= -MaxX && transform.position.x <= MaxX)
        {

            transform.Translate(x * speed * Vector2.right);

            // transform.Translate(x * -speed * Vector2.down);
        }
        else if (transform.position.x > MaxX)
        {
            Vector3 offset = transform.position - Vector3.right * MaxX;
            transform.position -= Vector3.right * offset.x;
        }
        else if (transform.position.x < -MaxX)
        {
            Vector3 offset = transform.position - Vector3.left * MaxX;
            transform.position += Vector3.left * offset.x;
        }
        
    }
}
