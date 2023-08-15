using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiemSo : MonoBehaviour
{
    public TextMeshProUGUI diem;
    public TextMeshProUGUI diemwin;
    public TextMeshProUGUI diemlose;

    public float diemcount;
    public float diemsize = 20f;
    public float diemluu;

    public GameObject cap1;
    public GameObject cap2;
    public GameObject cap3;
    public GameObject cap4;
    public GameObject cap5;
    public GameObject cap6;
    public GameObject cap7;
    public GameObject cap8;
    public GameObject cap9;
    public GameObject cap10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diemcount += ZombieEnemy.isdiem;
        ZombieEnemy.isdiem = 0;

        if (diemcount == 20 )
        {
            diemcount += 1f;
            diemsize = 40;
            Time.timeScale = 0;
            cap1.SetActive( true );

        }

        if(diemcount == 40 )
        {
            diemcount += 1f;
            diemsize = 80;
            Time.timeScale = 0;
            cap2.SetActive( true );
        }

        if(diemcount == 80)
        {
            diemcount += 1f;
            diemsize = 160;
            Time.timeScale = 0;
            cap3.SetActive( true );
        }

        if(diemcount == 160)
        {
            diemcount += 1f;
            diemsize = 240;
            Time.timeScale = 0;
            cap4.SetActive( true );
        }

        if(diemcount == 240)
        {
            diemcount += 1f;
            diemsize = 360;
            Time.timeScale = 0;
            cap5.SetActive( true );
        }

        if(diemcount == 360)
        {
            diemcount += 1f;
            diemsize = 540;
            Time.timeScale = 0;
            cap6.SetActive( true );
        }

        if(diemcount == 540)
        {
            diemcount += 1f;
            diemsize = 702;
            Time.timeScale = 0;
            cap7.SetActive( true );
        }

        if(diemcount == 702)
        {
            diemcount += 1f;
            diemsize = 842;
            Time.timeScale = 0;
            cap8.SetActive( true );
        }

        if(diemcount == 842)
        {
            diemcount += 1f;
            diemsize = 926;
            Time.timeScale = 0;
            cap9.SetActive( true );
        }

        if(diemcount == 926)
        {
            diemcount += 1f;
            diemsize = diemcount;
            Time.timeScale = 0;
            cap10.SetActive( true );
        }

        if(diemcount > 926)
        {
            diem.text = diemcount.ToString();
        }
        else
        {
            diem.text = diemcount.ToString() + " / " + diemsize.ToString();
        }
       
        
        diemwin.text = diemcount.ToString();
        diemlose.text = diemcount.ToString();
    }

    public void Reset()
    {
        SceneManager.LoadScene(1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
