using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerOne : MonoBehaviour
{
    public static string greenPlayer1ColName;


    void Start()
    {
        greenPlayer1ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            greenPlayer1ColName = collision.gameObject.name;
        }

    }
}

