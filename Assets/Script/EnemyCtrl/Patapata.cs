using UnityEngine;
using System.Collections;

public class Patapata : MonoBehaviour
{
    private Vector3 startPos; //敵の初期位置
    public float speed = 5f; //移動速度
    public float moveRange = 10f; //移動範囲
    private float moveValue; //移動量を入れておく箱
    private bool isWayX = false; //falseだと下に、trueだと上に動く

    private Destroy destory;


    void Start()
    {
        startPos = transform.position;
        destory = GameObject.FindObjectOfType<Destroy>();
    }


    void Update()
    {
        //上に移動
        if (isWayX)
        {
            moveValue += Time.deltaTime * speed; //徐々に値を加算
            //限界まで移動したら下に反転
            if (moveValue >= startPos.y + moveRange)
                isWayX = false;
        }
        //下に移動
        else
        {
            moveValue -= Time.deltaTime * speed; //徐々に値を減算
            //限界まで移動したら上に反転
            if (moveValue <= startPos.y + moveRange * -1f)
                isWayX = true;
        }

        transform.position = new Vector2(startPos.x, startPos.y + moveValue); //x軸は固定。y軸を毎回更新して移動させる
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        destory.OnTriggerEnter2D(coll);
    }
}
