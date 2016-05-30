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
        player = GameObject.Find("Player"); //プレイヤーを取得
        offset = transform.position - player.transform.position;
    }


    void Update()
    {
        //プレイヤーがデストロイされているならばカメラは動かさない
        if (player != null)
        {
            Vector3 targetCamPos = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(targetCamPos.x, transform.position.y, transform.position.z),
                10 * Time.deltaTime);
        }
    }
}
