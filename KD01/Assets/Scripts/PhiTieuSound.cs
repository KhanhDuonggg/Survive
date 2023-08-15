using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhiTieuSound : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("quai"))
        {
            audioSource.Play();
        }
    }
}
