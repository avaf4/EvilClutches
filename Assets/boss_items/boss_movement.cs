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

    private int n, m;

    // make ratio for how many dragons to babies

    bool goingUp = true;

    float futureTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("generateChild", 1, 0.5f);
        futureTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        n = UnityEngine.Random.Range(1, 4);
        m = UnityEngine.Random.Range(0.32, 0.44);

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

        // everytime b is pressed, create a new baby
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject obj = Instantiate(babyPrefab);
            obj.transform.position = transform.position;
            Debug.Log(Time.time);
        }
        // we have reached future time
        if (Time.time > futureTime)
        {
            GameObject obj = Instantiate(babyPrefab);
            obj.transform.position = transform.position;
            futureTime = Time.time + 1f;
        }


        // invoke function every 0.5 second


        // make function that generates random number 1 or 2, and instantiate baby or demon gameObject based on number
    }

    void generateChild()
    {

        // re invoke function within itself 
        if (n != 3)
        {
            GameObject objD;

            objD = Instantiate(demonPrefab);

            // move the fireball to the dragon's position
            objD.transform.position = transform.position + Vector3.right * xChildOffset + Vector3.up * yChildOffset;
        }
        else if (n == 3)
        {
            GameObject objB;

            objB = Instantiate(babyPrefab);

            // move the fireball to the dragon's position
            objB.transform.position = transform.position + Vector3.right * xChildOffset + Vector3.up * yChildOffset;
        }


    }
}
