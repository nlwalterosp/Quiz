using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Bstart : MonoBehaviour
{
    public Button bustart;
    // Start is called before the first frame update
    void Start()
    {
        bustart.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene("Cuerpo", LoadSceneMode.Additive); 
    }

}
