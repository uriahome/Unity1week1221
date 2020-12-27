using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMagazine : MonoBehaviour
{
    public GameObject MyCannon;
    public Cannon MyCannonScript;
    // Start is called before the first frame update
    void Start()
    {
        MyCannonScript = MyCannon.GetComponent<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(MyCannonScript.NowShotCount){//かなり無理やりだがとりあえずこれでいい
            case 1:
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            break;
            case 2:
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            break;
            case 3:
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            break;
            default:
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            break;
        }
    }
}
