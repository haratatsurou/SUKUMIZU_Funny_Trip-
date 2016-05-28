using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject kuribou;
    public GameObject patapata;
    private Vector3 kuribouStartPos;
    public float kuribouSpeed = 5f;
    public float kuribouMoveRange = 20f;
    private float moveValue;
    private bool isMoveX;


    void Start()
    {
        kuribouStartPos = kuribou.transform.position;
    }


    void Update()
    {
        if (kuribou != null)
        {
            if (isMoveX)
            {
                moveValue += Time.deltaTime * kuribouSpeed;
                if (moveValue >= kuribouStartPos.x + kuribouMoveRange)
                    isMoveX = false;
            }
            else
            {
                moveValue -= Time.deltaTime * kuribouSpeed;
                if (moveValue <= kuribouStartPos.x  + kuribouMoveRange * -1f)
                    isMoveX = true;
            }
            kuribou.transform.position = new Vector2(kuribouStartPos.x + moveValue, kuribouStartPos.y);
        }
    }
}
