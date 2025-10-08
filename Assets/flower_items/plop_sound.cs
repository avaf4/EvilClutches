using UnityEngine;

public class plop_sound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // in 0.5 seconds, invoke the plop function
        Invoke("Plop", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // object self-destructs
    void Plop()
    {
        Destroy(gameObject);
    }
}
