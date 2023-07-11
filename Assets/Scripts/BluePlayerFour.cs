using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerFour : MonoBehaviour
{
    public static string bluePlayer4ColName;
  

    void Start()
    {
        bluePlayer4ColName = "none";
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            bluePlayer4ColName = collision.gameObject.name;
        }
      
    }
 

}
