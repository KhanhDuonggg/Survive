using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhiTieu : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float playX = player.transform.position.x;
        float playY = player.transform.position.y;
        transform.position = new Vector3(playX, playY, 0);
    }

    
}
