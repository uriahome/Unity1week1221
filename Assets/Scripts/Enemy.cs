using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector3 MoveVelocity;//進むべき方向
    public bool HaveShield;//シールドを持っているなら

    void Start()
    {
        MoveVelocity = gameObject.transform.rotation * new Vector3(0.0f,speed,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        gameObject.transform.position += MoveVelocity*Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("nyaa");
        if(other.gameObject.tag=="Fire"){
            if(HaveShield){
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }   
    }
}
