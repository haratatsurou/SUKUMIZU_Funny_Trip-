using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float moveValue = 15f; //移動量
    public float jumpPower = 2.8f; //ジャンプ力
    private bool isGrounded = false; //地面に接触しているのか判定

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
       
        //ライトキーで右に移動
        if ( Input.GetKey(KeyCode.RightArrow) ) {
            transform.Translate(new Vector2(moveValue * Time.deltaTime , 0f)); //プレイヤーを右に
        }
        //レフトキーで左に移動
        else if ( Input.GetKey(KeyCode.LeftArrow) ) {
            transform.Translate(new Vector2(-moveValue * Time.deltaTime , 0f)); //プレイヤーを左に
        }
        //空中でジャンプできないように制限
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower * 1000f)); //上にジャンプ
            playerrenderer.sprite = jumpimage;
        }
    }


    //なにかに接触したらもう一度ジャンプできるようにする
    void OnCollisionStay2D(Collision2D coll)
    {
        isGrounded = true;
        playerrenderer.sprite = walkimage;
    }
}
//>>>>>>> master
