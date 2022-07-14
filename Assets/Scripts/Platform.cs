using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    GameObject topLine;
    Vector3 movement;

    public float speed;

    void Start()
    {
        movement.y = speed;
        topLine = GameObject.Find("TopLine");
    }

    void Update()
    {
        MovePlatform();
    }
    
    void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;

        if (transform.position.y >= topLine.transform.position.y)   //超出上边界
        {
            Destroy(gameObject);
        }
    }
}
