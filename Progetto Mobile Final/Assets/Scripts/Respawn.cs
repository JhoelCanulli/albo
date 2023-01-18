using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bordoDx")
            transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
        
        if (other.gameObject.tag == "bordoSx")
            transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);       

    }
}
