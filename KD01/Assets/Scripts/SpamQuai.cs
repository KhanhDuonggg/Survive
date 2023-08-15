using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamQuai : MonoBehaviour
{
    public GameObject vitriban;
    Vector3 viTriBan;
    public GameObject quai;

    public float istime;
    public float isSpawm;
    private float timeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        viTriBan = vitriban.transform.position;
        timeSpawn = istime;
    }

    // Update is called once per frame
    void Update()
    {
        isSpawm -= Time.deltaTime;
        if (isSpawm < 0)
        {
            isSpawm = 0;
            istime -= Time.deltaTime;
            if(istime < 0)
            {
                istime = timeSpawn;
                var quaimp = Instantiate(quai, viTriBan, Quaternion.identity);
            }
        }
    }
}
