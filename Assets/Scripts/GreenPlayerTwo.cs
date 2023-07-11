using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerTwo : MonoBehaviour
{
    public static string greenPlayer2ColName;


    void Start()
    {
        greenPlayer2ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            greenPlayer2ColName = collision.gameObject.name;
        }

    }
}


