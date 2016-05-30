using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    public float moveValue = 15f; //移動量
    public float jumpPower = 2.8f; //ジャンプ力
    private bool isGrounded = false; //地面に接触しているのか判定
    static public int witchWay = 1; //向いている方向。左が0, 右が1
    static public int countRockBuster = 0; //ロックバスターの発射数を制限

    public Sprite jumpimage,walkimage;

    private Rigidbody2D playerrigidbody;
    private Animator anime;
    private SpriteRenderer render;

    void Start()
    {
        countRockBuster = 0; //初期化
        playerrigidbody = GetComponent<Rigidbody2D>( );
        anime = GetComponent<Animator>( );
        anime.enabled = false;
        render = GetComponent<SpriteRenderer>( );
    }


    void Update()
    {
       
        //ライトキーで右に移動
        if ( Input.GetKey(KeyCode.RightArrow) ) {
            transform.Translate(new Vector2(moveValue * Time.deltaTime , 0f)); //プレイヤーを右に
            witchWay = 1;
            if ( isGrounded ) {
                anime.enabled = true;
            }
        }
        //レフトキーで左に移動
        else if ( Input.GetKey(KeyCode.LeftArrow) ) {
            transform.Translate(new Vector2(-moveValue * Time.deltaTime , 0f)); //プレイヤーを左に
            witchWay = 1;
            if ( isGrounded ) {
                anime.enabled = true;
            }
        }
        //空中でジャンプできないように制限
        Vector2 pastPos = transform.position;

            //空中でジャンプできないように制限
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower*1000f)); //上にジャンプ
            render.sprite = jumpimage;

            anime.enabled = false;
        }
        if( Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ) {
            anime.enabled=false;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpPower * 20f);
            if ( isGrounded ) {
                render.sprite = walkimage;
            }
           
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
    void OnTriggerStay2D(Collider2D col) {
        if ( col.tag == "goal" ) {

        }
        if ( col.tag == "Ground" || col.tag == "Object" ) {
            isGrounded = true;
            render.sprite = walkimage;
        }
    }
}
