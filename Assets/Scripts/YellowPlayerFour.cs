using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerFour : MonoBehaviour
{
    public static string yellowPlayer4ColName;


    void Start()
    {
        yellowPlayer4ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            yellowPlayer4ColName = collision.gameObject.name;
        }

    }



}