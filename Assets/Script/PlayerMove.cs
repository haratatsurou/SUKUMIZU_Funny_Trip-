using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float moveValue = 15f; //移動量
    public float jumpPower = 3f; //ジャンプ力
    private bool isGrounded = false; //地面に接触しているのか判定
    static public int witchWay = 1; //向いている方向。左が0, 右が1
    private Vector2 startScale;

    public Sprite jumpimage,walkimage;

    private Rigidbody2D playerrigidbody;
    private Animator anime;
    private SpriteRenderer render;
    //public LayerMask groundLayer;

    void Start()
    {
        startScale = transform.localScale; //大きさを取得
        playerrigidbody = GetComponent<Rigidbody2D>( );
        anime = GetComponent<Animator>( );
        anime.enabled = false;
        render = GetComponent<SpriteRenderer>( );
    }


    void Update()
    {
        //isGrounded = Physics2D.Linecast (transform.position, transform.position - transform.up * 0.05f, groundLayer);

        //ライトキーで右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(moveValue * Time.deltaTime, 0f)); //プレイヤーを右に
            transform.localScale = startScale; //画像を右に向ける
            witchWay = 1;

            if (isGrounded)
                anime.enabled = true;
        }
        //レフトキーで左に移動
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-moveValue * Time.deltaTime, 0f)); //プレイヤーを左に
            transform.localScale = new Vector2(-startScale.x, startScale.y); //画像を左に向ける
            witchWay = 0;

            if (isGrounded)
                anime.enabled = true;
        }
        
        //空中でジャンプできないように制限
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower * 1000f)); //上にジャンプ
            render.sprite = jumpimage;
            anime.enabled = false;
        }

        if( Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ) {
            anime.enabled=false;
            render.sprite = jumpimage;
        }
    }


    //なにかに接触したらもう一度ジャンプできるようにする
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Attack")
        {
            isGrounded = true;
            render.sprite = walkimage;
        }
    }
}
//>>>>>>> master
