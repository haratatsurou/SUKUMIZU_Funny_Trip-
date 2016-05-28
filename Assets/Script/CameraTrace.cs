using UnityEngine;
using System.Collections;
using System;

public class CameraTrace : MonoBehaviour
{
    //public float cameraY = 13f; //カメラのy軸(画面の上下を調整)
    //public float cameraZ = -50f; //カメラのz軸(画面の前後を調整)
    private GameObject player;
    Vector3 nowPos;

    Vector3 offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player"); //プレイヤーを取得
        offset = transform.position - player.transform.position;
    }

    
    void Update()
    {
<<<<<<< HEAD
     //   Vector3 nowPos = transform.position; //カメラの位置情報を毎回取り出す
     //   Vector3 pastPos = new Vector3(transform.position.x, cameraY, cameraZ);

     ////   transform.position = new Vector3(player.transform.position.x, cameraY, cameraZ); //x軸だけプレイヤーと同じ移動量。y軸とz軸はお好みで
     //   //transform.position = nowPos; //カメラとプレイヤーの移動量を同期
     //   // = Vector3.Lerp(pastPos, nowPos, Time.deltaTime);

        Vector3 targetCamPos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(targetCamPos.x,transform.position.y,transform.position.z) , 
            10 * Time.deltaTime);
=======
        //プレイヤーがデストロイされているならばカメラは動かさない
        if (player != null)
            nowPos = new Vector3(player.transform.position.x, cameraY, cameraZ); //x軸だけプレイヤーと同じ移動量。y軸とz軸はお好みで 
    }

    void LateUpdate()
    {
        transform.position = nowPos; //カメラとプレイヤーの移動量を同期
>>>>>>> 9e26222bb47cfadd961e76debe76c8a683545a28
    }
}
