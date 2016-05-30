using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
    static public int countRockBuster; //ロックバスターの発射数を制限
    

    void Start () {
        countRockBuster = 0; //初期化
    }

    // Update is called once per frame
    void Update()
    {
        //ロックバスター
        if (countRockBuster < 3 && Input.GetKeyDown(KeyCode.Z))
        {
            //右に発射
            if (PlayerMove.witchWay == 1)
            {
                //Resourcesフォルダからprefabを引っ張ってきて複製
                Instantiate(Resources.Load("RockBuster"), new Vector2(transform.position.x + 5f, transform.position.y + 5f), Quaternion.identity);
            }
            //左に発射
            else if (PlayerMove.witchWay == 0)
            {
                //x軸をマイナスに。向きも変える
                Instantiate(Resources.Load("RockBuster"), new Vector2(transform.position.x - 5f, transform.position.y + 5f), new Quaternion(0f, 180f, 0f, 0f));
            }
            countRockBuster++;
        }
    }
}
