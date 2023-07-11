using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerFour : MonoBehaviour
{
    public static string redPlayer4ColName;


    void Start()
    {
        redPlayer4ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            redPlayer4ColName = collision.gameObject.name;
        }

    }
}


