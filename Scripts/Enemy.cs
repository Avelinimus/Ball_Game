using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Ball;
    public float difficult = 10000000000000f * UI.level; // * level
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ball").transform.position.x > transform.position.x) 
        {
            transform.position += new Vector3(difficult, 0, 0) * Time.deltaTime;
        }
        else if(GameObject.FindGameObjectWithTag("Ball").transform.position.x < transform.position.x)
        {
            transform.position -= new Vector3(difficult, 0, 0) * Time.deltaTime;
        }
    }
}
