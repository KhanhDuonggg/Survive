using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveInput;
    private Animator animator;

    public GameObject phiTieu1;
    public GameObject phiTieu2;
    public GameObject phiTieu3;
    public GameObject phiTieu4;
    public GameObject phiTieu5;

    public GameObject sung1;
    public GameObject sung2;

    public GameObject pause;

    public static float damesung;

    //public AudioSource audioSource;
    //public SpriteRenderer characterSR;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    private void Update()
    {

        //audioSource.Play();
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(x, y, 0).normalized;
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("run", moveInput.sqrMagnitude);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - transform.position;

        if (lookDir.x != 0)
        {
            if (lookDir.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if(Input.GetKeyDown(KeyCode.P)) {
            Paused();
        }
    }

    public void Scle()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void PhiTieu1()
    {
        phiTieu1.SetActive(true);
        Time.timeScale = 1;
    }

    public void PhiTieu2()
    {
        phiTieu2.SetActive(true);
        Time.timeScale = 1;
    }

    public void PhiTieu3()
    {
        phiTieu3.SetActive(true);
        Time.timeScale = 1;
    }

    public void PhiTieu4()
    {
        phiTieu4.SetActive(true);
        Time.timeScale = 1;
    }

    public void PhiTieu5()
    {
        phiTieu5.SetActive(true);
        Time.timeScale = 1;
    }

    public void sung()
    {
        sung1.SetActive(true);
        Time.timeScale = 1;
    }

    public void sung01()
    {
        sung2.SetActive(true);
        Time.timeScale = 1;
    }

    public void Dame()
    {
        damesung += 0.2f;
        Time.timeScale = 1;
    }

    public void Paused()
    {
      Time.timeScale = 0;
        pause.SetActive(true);
    }
}
