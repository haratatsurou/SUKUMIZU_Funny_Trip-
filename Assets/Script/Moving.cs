
﻿using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    public float cameraY = 13f; //カメラのy軸(画面の上下を調整)
    public float cameraZ = -50f; //カメラのz軸(画面の前後を調整)
    public float moveValue = 15f; //移動量
    public float jumpPower = 2.8f; //ジャンプ力
    bool isGrounded = false; //地面に接触しているのか判定


    public Sprite jumpimage,walkimage;

    private Rigidbody2D playerrigidbody;
    private SpriteRenderer playerrenderer;

    void Start()
    {
        playerrigidbody = GetComponent<Rigidbody2D>( );
        playerrenderer = GetComponent<SpriteRenderer>( );
    }


    void Update()
    {
        Vector3 nowPos = Camera.main.transform.position; //カメラの位置情報を毎回取り出す

        //ライトキーで右に移動
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(new Vector2(moveValue * Time.deltaTime, 0f)); //プレイヤーを右に
        //レフトキーで左に移動
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(new Vector2(-moveValue * Time.deltaTime, 0f)); //プレイヤーを左に

        //空中でジャンプできないように制限
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower * 1000f)); //上にジャンプ
            isGrounded = false;
        }

        nowPos = new Vector3(transform.position.x, cameraY, cameraZ); //x軸だけプレイヤーと同じ移動量。y軸とz軸はお好みで
        Camera.main.transform.position = nowPos; //カメラとプレイヤーの移動量を同期
    }


    //なにかに接触したらもう一度ジャンプできるようにする
    void OnCollisionEnter2D(Collision2D coll)
    {
        isGrounded = true;
        playerrenderer.sprite = walkimage;
    }
}
//>>>>>>> master
