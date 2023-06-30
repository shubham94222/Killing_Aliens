using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target; // the player's transform
    public float speed = 5f; // the speed at which the enemy follows the player

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // calculate the direction to the target
        Vector3 direction = target.position - transform.position;

        // normalize the direction to get a unit vector
        direction.Normalize();

        // rotate towards the target
        transform.LookAt(target);

        // move towards the target
        transform.position += direction * speed * Time.deltaTime;

        // set the animator bool parameter based on the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget > 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
