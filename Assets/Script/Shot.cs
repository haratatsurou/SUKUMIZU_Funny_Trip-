using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
    static public int countRockBuster; //ロックバスターの発射数を制限


    void Start() {
        countRockBuster = 0; //初期化
    }

    // Update is called once per frame
    void Update() {
        //ロックバスター
        if ( countRockBuster < 3 && Input.GetKeyDown(KeyCode.Z) ) {
            //Resourcesフォルダからprefabを引っ張ってきて複製
            Instantiate(Resources.Load("RockBuster") , new Vector2(transform.position.x + 5f , transform.position.y + 5f) , Quaternion.identity);
            countRockBuster++;
        }
    }
}
