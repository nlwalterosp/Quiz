using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class play : MonoBehaviour
{
    Vector3 mp;
    public Button bt1,bt2,bt3,bt4,bt5;
    int p;

    

    // Start is called before the first frame update
    void Start()
    {
        mp.x = 0;
        mp.y = 0;
        p = 1; 
        bt1.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (p == 1) { }
        if (p == 2) { }

    } 
    void TaskOnClick()
    {
        p = 2;
        mp.x =-5; mp.y = 2; transform.position = mp;

    }
}
