using UnityEngine;
using UnityEngine.UIElements;

public class boss_movement : MonoBehaviour
{
    // set the boss's speed from the inspector
    public float speed = 0.008f;
    public float MaxY = 3.8f;    
    public float MinY = -3.9f;

    bool goingUp = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp == true)
        {
            transform.Translate(Vector2.up * speed);
        }
        else
        {
            transform.Translate(Vector2.down * speed);
        }
        // if we hit the max, change direction and go down
        if (transform.position.y >= MaxY)
        {
            goingUp = false;
        }
        // if we hit the bottom, change direction and go up
        else if (transform.position.y <= MinY)
        {
            goingUp = true;
        }

    }
}
