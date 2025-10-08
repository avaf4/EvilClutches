using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class boss_movement : MonoBehaviour
{
    // set the boss's speed from the inspector
    public float speed = 0.008f;
    public float MaxY = 3.8f;
    public float MinY = -3.9f;

    public GameObject babyPrefab;
    public GameObject demonPrefab;
    public float xChildOffset = 0f;
    public float yChildOffset = 0f;

    public float randomTime1 = 0.2f, randomTime2 = 0.5f;
    private double n, m;

    // make ratio for how many dragons to babies

    bool goingUp = true;

    double futureTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("generateChild", 1, (float)m);
        futureTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        n = UnityEngine.Random.Range(0f, 1f);
        m = UnityEngine.Random.Range(randomTime1, randomTime2);

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

        // we have reached future time
        if (Time.time > futureTime)
        {
            GameObject obj = Instantiate(babyPrefab);
            obj.transform.position = transform.position;
            futureTime = Time.time + m;
        }


        // invoke function every 0.5 second


        // make function that generates random number 1 or 2, and instantiate baby or demon gameObject based on number
    }

    void generateChild()
    {
        GameObject obj;
        // re invoke function within itself 
        if (n < 0.8f)
        {
            obj = Instantiate(demonPrefab);

            // move the fireball to the dragon's position
            obj.transform.position = transform.position + Vector3.right * xChildOffset + Vector3.up * yChildOffset;
        }
        else
        {
            obj = Instantiate(babyPrefab);

            // move the fireball to the dragon's position
            obj.transform.position = transform.position + Vector3.right * xChildOffset + Vector3.up * yChildOffset;
        }


    }
}
