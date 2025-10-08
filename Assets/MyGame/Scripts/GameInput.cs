using UnityEngine;

public class GameInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) )
        {
            Debug.Log("space key");
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Horizontal axis value " + Input.GetAxis("Horizontal"));
        }
    }
}
