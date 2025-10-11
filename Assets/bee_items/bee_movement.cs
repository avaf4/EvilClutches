using UnityEngine;

public class bee_movement : MonoBehaviour
{
    public float speed = 4f;
    public float MaxX = 6;
    public GameObject PollenPrefab;
    private float x;
    public float fireball_x_offset = 0f;
    public float fireball_y_offset = 0f;   
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

            transform.Translate(x * speed * Vector2.right * Time.deltaTime);

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

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject obj;

            obj = Instantiate(PollenPrefab);

            // move the fireball to the dragon's position
            obj.transform.position = transform.position + Vector3.right * fireball_x_offset + Vector3.up * fireball_y_offset;
        }
        
    }
}
