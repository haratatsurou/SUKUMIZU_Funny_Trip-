using UnityEngine;
using System.Collections;

public class Kuribou : MonoBehaviour {
    private Vector3 startPos; //敵の初期位置
    public float speed = 5f; //移動速度
    public float moveRange = 20f; //移動範囲
    private float moveValue; //移動量を入れておく箱
    private bool isWayX = false; //falseだと左に、trueだと右に動く


    void Start () {
        startPos = transform.position;
    }


    void Update()
    {
        //右に移動
        if (isWayX)
        {
            moveValue += Time.deltaTime * speed; //徐々に値を加算
            //限界まで移動したら左に反転
            if (moveValue >= startPos.x + moveRange)
                isWayX = false;
        }
        //左に移動
        else
        {
            moveValue -= Time.deltaTime * speed; //徐々に値を減算
            //限界まで移動したら右に反転
            if (moveValue <= startPos.x + moveRange * -1f)
                isWayX = true;
        }

        transform.position = new Vector2(startPos.x + moveValue, startPos.y); //y軸は固定。x軸を毎回更新して移動させる
    }
}
