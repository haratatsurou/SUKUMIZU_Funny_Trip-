using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {

    }


    //敵に当たるか、下に落ちるかすると死亡
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
            SceneManager.LoadScene("stage01"); //リスタート
        }
    }
}
