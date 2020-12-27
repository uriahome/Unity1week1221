using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Ghosts;
    public float span;
    public float delta;
    public int SelectNum;//召喚するゴーストの番号
    void Start()
    {
        delta =0;
    }

    // Update is called once per frame
    void Update()
    {
        if(span < delta){//行動をする
            delta = 0;
            SelectNum = Random.Range(0,3);//ランダムに1枚選択
            int A = Random.Range(0,101);
            if(A%2==0){
                GameObject GhostObj = Instantiate(Ghosts[SelectNum]) as GameObject;//弾の生成
                GhostObj.transform.position = new Vector3(1.32f, -5.12f, this.transform.position.z);//自分の場所に出す
            }else{
                GameObject GhostObj = Instantiate(Ghosts[SelectNum]) as GameObject;//弾の生成
                GhostObj.transform.position = new Vector3(-3.84f, -5.12f, this.transform.position.z);//自分の場所に出す
            }

        }else{
            this.delta += Time.deltaTime;
        }
    }
}
