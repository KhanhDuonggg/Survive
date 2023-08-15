using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dichuyentheochuot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public GameObject muzzle;

    public float TimeBtwFire ;
    public float bulletForce;

    private float timeBtwFire;
    
    void Update()
    {
        RotateKiem();
        timeBtwFire -= Time.deltaTime;
        if ( timeBtwFire < 0)
        {
            FireBullet();
        }
    }

    public void RotateKiem()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        
        Quaternion rotation = Quaternion.Euler(0,0,angle);
        transform.rotation = rotation;
        
        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(-1, -1, 0);

        }
        else
        {
            transform.localScale = new Vector3(1,1, 0);
        }
    }

    public void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Instantiate(muzzle, firePos.position, transform.rotation, transform);

        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    public void TocDo()
    {
        TimeBtwFire -= 0.2f;
        Time.timeScale = 1;
    }
}
