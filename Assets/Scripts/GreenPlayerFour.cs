using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerFour : MonoBehaviour
{
    public static string greenPlayer4ColName;


    void Start()
    {
        greenPlayer4ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            greenPlayer4ColName = collision.gameObject.name;
        }

    }


}