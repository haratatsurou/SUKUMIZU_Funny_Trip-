using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject kuribou;
    public GameObject patapata;
    private Vector3 kuribouStartPos;
    public float kuribouSpeed = 5f;
    private Vector2 loopX = Vector2.zero;


    void Start()
    {
        kuribouStartPos = kuribou.transform.position;
    }


    void Update()
    {
        loopX.x = loopX.x + Time.deltaTime * kuribouSpeed;
        if (kuribou.transform.position.x <= 40f)
            kuribouSpeed = -5f;
        else if (-40f <= loopX.x)
            kuribouSpeed = 5f;

    }
}
