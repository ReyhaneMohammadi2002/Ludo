using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerOne : MonoBehaviour
{
    public static string bluePlayer1ColName;


    void Start()
    {
        bluePlayer1ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            bluePlayer1ColName = collision.gameObject.name;
        }

    }


}