using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;//速度
    //public Vector3 CannonVelocity;//大砲から出たときの向き
    public Vector3 MoveVelocity;//進むべき方向
    // Start is called before the first frame update
    void Start()
    {
        //MoveVelocity = CannonVelocity*new vector3(speed,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        gameObject.transform.position += MoveVelocity*Time.deltaTime;

    }
    public void SetVelocity(float rotationZ){
        this.gameObject.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);
        MoveVelocity = gameObject.transform.rotation * new Vector3(0.0f,speed,0.0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="EnemyShield"){
            Destroy(this.gameObject);
        }   
    }
}
