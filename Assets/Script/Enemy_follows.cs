using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follows : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 0.7f;
    public float detectionDistance = 2f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionDistance)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Reset the bool parameter in the Animator component when the left mouse button is released
            animator.SetBool("IsRunning", true);

        }
        else 
        {
            animator.SetBool("IsRunning", false);
        }
    }
  
}
