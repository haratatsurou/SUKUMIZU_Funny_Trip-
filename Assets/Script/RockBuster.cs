using UnityEngine;
using System.Collections;

public class RockBuster : MonoBehaviour
{

	
	void Start () {
            GetComponent<Rigidbody2D>().velocity = new Vector2(40f, 20f); //放物線を描くように発射
        Destroy(this.gameObject , 5f);
    }
	
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        //敵にあったったら削除する
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
        }
        //フィールドオブジェクトに当たったらロックバスターを削除
        else if (coll.gameObject.tag == "Ground")
        {
            Destroy(gameObject); //ロックバスターを削除
           
        }
    }
    void OnDestroy() {
        Shot.countRockBuster--; //削除した分、発射制限を緩和
    }
}
