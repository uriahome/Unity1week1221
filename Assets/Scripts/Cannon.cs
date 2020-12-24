using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject ShotObject;//発射するオブジェクト
    public float span;//弾がたまるまでの間隔
    public float delta;//溜めている時間
    public int MaxShotCount;//溜められる弾の最大の数
    public int NowShotCount;//現在溜めている弾の数
    public bool isAttack;//trueなら攻撃中、falseならチャージ中
    // Start is called before the first frame update
    void Start()
    {
        delta = 0;
        NowShotCount = 0;
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttack){
            if(NowShotCount>=1){
                StartCoroutine("Attack");
                NowShotCount--;
            }
        }else{
            if(span < delta){
                Debug.Log("チャージ");
                NowShotCount++;
                delta = 0;
                if(NowShotCount>=MaxShotCount){
                    NowShotCount = MaxShotCount;
                }
            }else{
                this.delta += Time.deltaTime;
            }
        }
    }

    public void OnClickAction(){//クリックされたときの行動
    Debug.Log("クリックされました！");
    isAttack = !isAttack;
    }
    public IEnumerator Attack(){
        int Count = 0;
        float interval = 0.1f;
        while (true)
        {
            Count++;
            if (Count > 10)
            {
                GameObject FireObj = Instantiate(ShotObject) as GameObject;//弾の生成
                Fire FireScript = FireObj.GetComponent<Fire>();
                FireScript.SetVelocity(gameObject.transform.localEulerAngles.z);
                FireObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.x, this.transform.position.z);//自分の場所に出す
                Debug.Log("oaaa");
                yield break;
            }
            yield return new WaitForSeconds(interval);
        }
    }


}
