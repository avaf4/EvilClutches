using UnityEngine;

public class spray_bottle : MonoBehaviour
{
    public float speed = 4f;
    public GameObject FireballPrefab;
    public float MaxY = 3f;

    public float fireball_x_offset = 0f;
    public float fireball_y_offset = 0f;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");

        if (transform.position.y >= -MaxY && transform.position.y <= MaxY){

            transform.Translate(y * speed * Time.deltaTime  * Vector2.up);
            // transform.Translate(y * -speed * Vector2.down);
        }
        else if (transform.position.y > MaxY)
        {
            Vector3 offset = transform.position - Vector3.up * MaxY;
            transform.position -= Vector3.up * offset.y;
        }
        else if (transform.position.y < -MaxY)
        {
            Vector3 offset = transform.position - Vector3.down * MaxY;
            transform.position += Vector3.down * offset.y;
        }

        // button
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject obj;

            obj = Instantiate(FireballPrefab);

            // move the fireball to the dragon's position
            obj.transform.position = transform.position + Vector3.right * fireball_x_offset + Vector3.up * fireball_y_offset;
        }

    }
}
