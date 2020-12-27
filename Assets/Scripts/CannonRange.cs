using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRange : MonoBehaviour
{
    public GameObject LookTarget;//見つけたターゲットの座標
    public bool DetectEnemy;//エネミーを見つけているかどうか
    public Cannon MyCannon;//自分の親オブジェクト
    public Vector3 angle;//角度君
    // Start is called before the first frame update
    void Start()
    {
        MyCannon = GetComponentInParent<Cannon>();
        DetectEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            DetectEnemy = true;//当たってるよー
            LookTarget = other.gameObject;//どこにいるかわかるよー
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            DetectEnemy = false;//当たって（ないです
            LookTarget = null;//見失ったわ
        }
    }
}
