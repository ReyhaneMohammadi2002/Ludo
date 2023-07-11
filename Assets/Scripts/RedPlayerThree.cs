using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerThree : MonoBehaviour
{
    public static string redPlayer3ColName;


    void Start()
    {
        redPlayer3ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            redPlayer3ColName = collision.gameObject.name;
        }

    }



}

