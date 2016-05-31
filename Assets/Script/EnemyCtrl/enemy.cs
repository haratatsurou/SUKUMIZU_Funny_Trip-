using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    private Vector3 startPos; //敵の初期位置
    public float speed = 5f; //移動速度
    public float moveRange = 10f; //移動範囲
    public EnemyMode enemymode;
    public enum EnemyMode {
        Kuribo,
        PataPata,
    }
    void Start() {
        startPos = transform.position;
    }


    void Update() {
        var pingpong = Mathf.PingPong(Time.time*speed ,moveRange);
        if ( enemymode == EnemyMode.Kuribo ) {
            transform.position = new Vector2(startPos.x +  pingpong, startPos.y); 
        }
        if ( enemymode == EnemyMode.PataPata ) {
            transform.position = new Vector2(startPos.x , startPos.y + pingpong); 
        }
    }

}
