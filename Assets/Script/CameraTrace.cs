using UnityEngine;
using System.Collections;
using System;

public class CameraTrace : MonoBehaviour
{
    public float cameraY = 13f; //カメラのy軸(画面の上下を調整)
    public float cameraZ = -50f; //カメラのz軸(画面の前後を調整)
    private GameObject player;
    Vector3 nowPos;


    void Start()
    {
        player = GameObject.FindWithTag("Player"); //プレイヤーを取得
    }

    
    void Update()
    {
        //プレイヤーがデストロイされているならばカメラは動かさない
        if (player != null)
            nowPos = new Vector3(player.transform.position.x, cameraY, cameraZ); //x軸だけプレイヤーと同じ移動量。y軸とz軸はお好みで 
    }

    void LateUpdate()
    {
        transform.position = nowPos; //カメラとプレイヤーの移動量を同期
    }
}
