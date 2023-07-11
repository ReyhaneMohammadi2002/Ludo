using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerTwo : MonoBehaviour
{
    public static string bluePlayer2ColName;


    void Start()
    {
        bluePlayer2ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            bluePlayer2ColName = collision.gameObject.name;
        }

    }


}