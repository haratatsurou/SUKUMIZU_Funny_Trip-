using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float moveValue = 15f; //移動量
    public float jumpPower = 2.8f; //ジャンプ力
    private bool isGrounded = false; //地面に接触しているのか判定
    static public int witchWay = 1; //向いている方向。左が0, 右が1
    static public int countRockBuster = 0; //ロックバスターの発射数を制限

    public Sprite jumpimage,walkimage;

    private Rigidbody2D playerrigidbody;
    private SpriteRenderer playerrenderer;

    void Start()
    {
        countRockBuster = 0; //初期化
        playerrigidbody = GetComponent<Rigidbody2D>( );
        playerrenderer = GetComponent<SpriteRenderer>( );
    }


    void Update()
    {
        Vector2 pastPos = transform.position;
        //ライトキーで右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(moveValue * Time.deltaTime, 0f)); //プレイヤーを右に
            witchWay = 1;
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(moveValue, 0f));
        }
        //レフトキーで左に移動
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-moveValue * Time.deltaTime, 0f)); //プレイヤーを左に
            witchWay = 0;
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveValue, 0f));
        }

        //if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            //空中でジャンプできないように制限
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower * 1000f)); //上にジャンプ
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpPower * 20f);
            playerrenderer.sprite = jumpimage;
        }

        //ロックバスター
        if (countRockBuster < 3 && Input.GetKeyDown(KeyCode.Z))
        {
            //右に発射
            if (witchWay == 1)
            {
                //Resourcesフォルダからprefabを引っ張ってきて複製
                Instantiate(Resources.Load("RockBuster"), new Vector2(transform.position.x + 5f, transform.position.y + 5f), Quaternion.identity);
            }
            //左に発射
            else if(witchWay == 0)
            {
                //x軸をマイナスに。向きも変える
                Instantiate(Resources.Load("RockBuster"), new Vector2(transform.position.x - 5f, transform.position.y + 5f), new Quaternion(0f, 180f, 0f, 0f));
            }
            countRockBuster++;

        }
    }


    //なにかに接触したらもう一度ジャンプできるようにする
    void OnCollisionEnter2D(Collision2D coll)
    {
        isGrounded = true;
        playerrenderer.sprite = walkimage;
    }
}
//>>>>>>> master
