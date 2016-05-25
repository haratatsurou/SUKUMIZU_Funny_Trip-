using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    public float cameraY = 13f;
    public float cameraZ = -50f;
    public float moveValue = 15f; //移動量
    public float jumpPower = 2.8f; //ジャンプ力
    bool isGrounded = false; //地面に接触しているのか判定


    void Start()
    {

    }


    void Update()
    {
        Vector3 nowPos = Camera.main.transform.position;

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

        nowPos = new Vector3(transform.position.x, cameraY, cameraZ);
        Camera.main.transform.position = nowPos;
    }


    //なにかに接触したらもう一度ジャンプできるようにする
    void OnCollisionEnter2D(Collision2D coll)
    {
        isGrounded = true;
    }
}
