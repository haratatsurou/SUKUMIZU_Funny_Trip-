using UnityEngine;
using System.Collections;

public class RockBuster : MonoBehaviour
{


	
	void Start () {
        if(PlayerMove.witchWay == 1)
            GetComponent<Rigidbody2D>().velocity = new Vector2(40f, 20f); //放物線を描くように発射
        else if(PlayerMove.witchWay == 0)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-40f, 20f); //左側に発射
    }
	
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        //敵にあったったら消す(見えなくする)
        if (coll.gameObject.tag == "Enemy")
        {
            coll.GetComponent<SpriteRenderer>().enabled = false;
            coll.GetComponent<BoxCollider2D>().enabled = false;
        }
        //フィールドオブジェクトに当たったらロックバスターを削除
        else if (coll.gameObject.tag == "Ground")
        {
            Destroy(gameObject); //ロックバスターを削除
            PlayerMove.countRockBuster--; //削除した分、発射制限を緩和
        }
    }
}
