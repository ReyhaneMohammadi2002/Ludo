 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerThree : MonoBehaviour
{
    public static string greenPlayer3ColName;


    void Start()
    {
        greenPlayer3ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            greenPlayer3ColName = collision.gameObject.name;
        }

    }
}

