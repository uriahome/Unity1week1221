using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GM;
    public GManager GMan;
    void Start()
    {
        GM = GameObject.Find("GameManager");
        GMan = GM.GetComponent<GManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enemy"){
            GMan.Lose();
            Destroy(this.gameObject);
        }   
    }
}
