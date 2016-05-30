using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    public float moveValue = 15f; //移動量
    public float jumpPower = 3f; //ジャンプ力
    private bool isGrounded = false; //地面に接触しているのか判定

    public Sprite jumpimage,walkimage;

    private Animator anime;
    private SpriteRenderer render;

    void Start()
    {
        anime = GetComponent<Animator>( );
        anime.enabled = false;
        render = GetComponent<SpriteRenderer>( );
    }


    void Update()
    {
       
        //ライトキーで右に移動
        if ( Input.GetKey(KeyCode.RightArrow) ) {
            transform.Translate(new Vector2(moveValue * Time.deltaTime , 0f)); //プレイヤーを右に
            if ( isGrounded ) {
                anime.enabled = true;
            }
        }
        //レフトキーで左に移動
        else if ( Input.GetKey(KeyCode.LeftArrow) ) {
            transform.Translate(new Vector2(-moveValue * Time.deltaTime , 0f)); //プレイヤーを左に
            if ( isGrounded ) {
                anime.enabled = true;
            }
        }

        //ライトキーで右に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(moveValue * Time.deltaTime, 0f)); //プレイヤーを右に
        }
        //レフトキーで左に移動
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-moveValue * Time.deltaTime, 0f)); //プレイヤーを左に
        }

        
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
            render.sprite = jumpimage;
        }
    }
    //なにかに接触したらもう一度ジャンプできるようにする
    void OnTriggerStay2D(Collider2D col) {
        if ( col.tag == "goal" ) {
            GameObject.Find("UI").GetComponent<Canvas>( ).enabled = true;
            GameObject.Find("UI/Text").GetComponent<Text>( ).enabled = true;
            GameObject.Find("UI/Text").GetComponent<Text>( ).text = "クリアー";
            Invoke("restart" , 3f);
            var player = GameObject.Find("Player");
            player.GetComponent<PlayerMove>( ).enabled = false;
            player.GetComponent<Shot>( ).enabled = false;
            player.GetComponent<Animator>( ).enabled = false;
        }
        if ( col.tag == "death" ) {
            restart( );
        }
        if ( col.tag == "Ground" || col.tag == "Object" ) {
            isGrounded = true;
            render.sprite = walkimage;
        }
        if ( col.tag == "Enemy" ) {
            restart( );
        }
        
    }
    void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
