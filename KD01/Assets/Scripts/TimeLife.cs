using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLife : MonoBehaviour
{
    public TextMeshProUGUI phut;
    public TextMeshProUGUI giay;

    private float timeGiay = 60;

    private float timePhut = 14;

    public GameObject win;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTime());
    }

    // Update is called once per frame
    void Update()
    {

        if (timeGiay < 0)
        {
            timeGiay = 59;
            timePhut--;
        }

        phut.text = timePhut.ToString();
        if(timeGiay < 10)
        {
            giay.text = "0"+timeGiay.ToString();
        }
        else
        {
            giay.text = timeGiay.ToString();
        }

        if(timePhut < 0)
        {
            timeGiay = 00;
            timePhut = 0;
            giay.text = timeGiay.ToString();
            phut.text = timePhut.ToString();
            Time.timeScale = 0;
            win.SetActive(true);

        }

       
    }

    IEnumerator UpdateTime()
    {
        while (true)
        {
            timeGiay--;
            
            yield return new WaitForSeconds(1);
        }
    }
}
