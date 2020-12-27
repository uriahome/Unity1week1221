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
    protected CannonRange MyCannonRange;//自分の接敵範囲
    public Sprite[] CannonSprite;//キャノンの画像
    public SpriteRenderer MySprite;//表示している画像

    public Vector3 Mypos;//自分の座標
    public Vector3 Enemypos;//エネミーの座標
    public Vector3 Myangle;//自分の座標とエネミー座標の差
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        delta = 0;
        NowShotCount = 0;
        isAttack = false;
        MyCannonRange = this.GetComponentInChildren<CannonRange>();//子オブジェクトから取得
        MySprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(span < delta){//行動をする ちょっとif文が多すぎる
                delta = 0;
                if(isAttack){
                    if(NowShotCount >=1){
                        StartCoroutine("Attack");
                        NowShotCount--;
                    }
                }else{
                    NowShotCount++;
                    delta = 0;
                if(NowShotCount>=MaxShotCount){
                    NowShotCount = MaxShotCount;
                }
                }
        }else{
            this.delta += Time.deltaTime;
        }
        if (MyCannonRange.DetectEnemy == true){
            Mypos = transform.position;//自分の座標
            Enemypos = MyCannonRange.LookTarget.transform.position;//playerの座標
            Myangle = Enemypos - Mypos;//座標の差
            angle = Mathf.Atan2(Myangle.y, Myangle.x) * Mathf.Rad2Deg;//2点間の角度
            transform.rotation = Quaternion.Euler(0, 0, angle-90);//回転させる
        }

    }

    public void OnClickAction(){//クリックされたときの行動
    Debug.Log("クリックされました！");
    isAttack = !isAttack;
    }
    public IEnumerator Attack(){
    GameObject FireObj = Instantiate(ShotObject) as GameObject;//弾の生成
    Fire FireScript = FireObj.GetComponent<Fire>();
    FireScript.SetVelocity(gameObject.transform.localEulerAngles.z);
    FireObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);//自分の場所に出す
    Debug.Log("oaaa");
    yield break;
    }


}
