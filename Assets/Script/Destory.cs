using UnityEngine;
using System.Collections;

public class Destory : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
        }
    }
}
