using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GManager instance = null;
    public bool Battle;//戦闘中かどうか
    public GameObject Timer;
    public Text TimerText;
    public float CountTime;
    public int seconds;

    void Start()
    {
        if (instance == null)//1つだけ存在するようにする
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Timer = GameObject.Find("Canvas/Timer");
            TimerText = Timer.GetComponent<Text>();
            seconds = 1;
        }
        else
        {
            Destroy(this.gameObject);//被っていたら消える
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (seconds > 0)
        {
            CountTime -= Time.deltaTime;
        }else if(seconds <=0)
        {
            CountTime = -1;
            //勝利
        }
        seconds = (int)CountTime;
        TimerText.text = "Time:"+seconds.ToString();
    }
}
