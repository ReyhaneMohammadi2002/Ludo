using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerOne : MonoBehaviour
{
    public static string redPlayer1ColName;


    void Start()
    {
        redPlayer1ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            redPlayer1ColName = collision.gameObject.name;
        }

    }



}
