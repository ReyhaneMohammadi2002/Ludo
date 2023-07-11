using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerOne : MonoBehaviour
{
    public static string yellowPlayer1ColName;


    void Start()
    {
        yellowPlayer1ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            yellowPlayer1ColName = collision.gameObject.name;
        }

    }



}
