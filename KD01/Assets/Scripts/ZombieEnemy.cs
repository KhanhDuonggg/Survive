using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieEnemy : MonoBehaviour
{
    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;
    public SpriteRenderer characterSR;

    public Seeker seeker;
    Path path;
    Coroutine moveCoroutine;
    bool reachDestination = false;
    public bool updateContinuesPath;

    public float healthEnemy;
    public float dame = 0;

    public static int isdiem;

    public AudioSource audioSource;
    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
        
    }

    private void Update()
    {
        dame += Player.damesung;
        Player.damesung = 0;
    }
    void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;
            }

            if (force.x != 0)
            {
                if (force.x < 0)
                {
                    characterSR.transform.localScale = new Vector3(-1f, 1f, 0);
                }
                else
                {
                    characterSR.transform.localScale = new Vector3(1f, 1f, 0);
                }
            }

            yield return null;

        }
        reachDestination = true;
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        if (roaming)
        {
            return (Vector2)playerPos + (Random.Range(5f, 10f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
        }
        else
        {
            return playerPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            audioSource.Play();
            healthEnemy -= (1 + dame);
            Destroy(collision.gameObject);
            if (healthEnemy <= 0)
            {
                isdiem = 1;
                Destroy(gameObject,0.2f);
            }
            

        }

        if (collision.gameObject.CompareTag("phitieu"))
        {
            healthEnemy -= 3;
            if (healthEnemy <= 0)
            {
                isdiem = 1;
                Destroy(gameObject);
            }
        }
    }

   

}

