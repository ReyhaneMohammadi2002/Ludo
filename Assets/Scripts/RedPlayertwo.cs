using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayertwo : MonoBehaviour
{
    public static string redPlayer2ColName;


    void Start()
    {
        redPlayer2ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            redPlayer2ColName = collision.gameObject.name;
        }

    }



}
