using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BigZombie : MonoBehaviour
{
    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;
    public SpriteRenderer characterSR;
    private Animator animator;

    public Seeker seeker;
    Path path;
    Coroutine moveCoroutine;
    bool reachDestination = false;
    public bool updateContinuesPath;

    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
        animator = GetComponent<Animator>();
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
            animator.SetFloat("run", direction.sqrMagnitude);

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if(distance < nextWPDistance)
            {
                currentWP++;
            }

            if(force.x != 0)
            {
                if(force.x < 0)
                {
                    characterSR.transform.localScale = new Vector3(-1.5f, 1.5f, 0);
                }
                else
                {
                    characterSR.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                }
            }

            yield return null;

        }
        reachDestination = true;
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;   
        if(roaming)
        {
            return (Vector2)playerPos + (Random.Range(5f, 10f) * new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized);
        }
        else
        {
            return playerPos;
        }
    }

}
