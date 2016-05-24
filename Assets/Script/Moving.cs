using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    public float moveValue = 15f; //移動量
    public float jumpPower = 2.8f; //ジャンプ力
    bool isGrounded = false; //地面に接触しているのか判定


    void Start()
    {

    }


    void Update()
    {
        //ライトキーで右に移動
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(new Vector2(moveValue * Time.deltaTime, 0f));
        //レフトキーで左に移動
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(new Vector2(-moveValue * Time.deltaTime, 0f));
        
        //空中でジャンプできないように制限
        if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower * 1000f));
            isGrounded = true;
        }
    }


    //なにかに接触したらもう一度ジャンプできるようにする
    void OnCollisionEnter2D(Collision2D coll)
    {
        isGrounded = false;
    }
}
