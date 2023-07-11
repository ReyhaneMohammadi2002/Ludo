using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerTwo : MonoBehaviour
{
    public static string yellowPlayer2ColName;


    void Start()
    {
        yellowPlayer2ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            yellowPlayer2ColName = collision.gameObject.name;
        }

    }



}
