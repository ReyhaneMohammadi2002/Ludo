using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerthree : MonoBehaviour
{
    public static string bluePlayer3ColName;


    void Start()
    {
        bluePlayer3ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            bluePlayer3ColName = collision.gameObject.name;
        }

    }


}