using UnityEngine;

public class dragon : MonoBehaviour
{
    public float speed = 0.004f;
    public GameObject FireballPrefab;

    public float fireball_x_offset = 0f;
    public float fireball_y_offset = 0f;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y;
        y = Input.GetAxis("Vertical");

        if (transform.position.y >= -4f && transform.position.y <= 4f){

            transform.Translate(y * speed * Vector2.up);

            // transform.Translate(y * -speed * Vector2.down);
        }
        else if (transform.position.y > 4f)
        {
            transform.Translate(y * speed * Vector2.down);
        }
        else if (transform.position.y < -4f)
        {
            transform.Translate(y * -speed * Vector2.up);
        }
        // else
        // {
        //     transform.Translate(0f, 0f, 0f);
        // }


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
