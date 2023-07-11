using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayerThree : MonoBehaviour
{
    public static string yellowPlayer3ColName;


    void Start()
    {
        yellowPlayer3ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            yellowPlayer3ColName = collision.gameObject.name;
        }

    }



}
