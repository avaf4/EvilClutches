using UnityEngine;
using UnityEngine.UIElements;

public class moving_background : MonoBehaviour
{
    public float speed = 0.005f;
    private Vector3 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0f, 0f);
        if (transform.position.x > 16f)
        {
            transform.position = new Vector3(-16f, transform.position.y, transform.position.z);
        }
    }
}

