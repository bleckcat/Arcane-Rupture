using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = .1f;
    public bool isRunningA = false;
    Animator animator;
    NavMeshAgent agent;
    int isWalkingHash;
    int isRunningHash;
    float lastTime = -1.0f;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("up");
        bool forwardDown = Input.GetKeyDown("up");

        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            gameObject.GetComponent<Movimentation>().speed = 3f;
            isRunningA = false;
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isRunningHash, false);
        }

        if (forwardDown)
        {
            if ((Time.time - lastTime) < 1f)
            {
                isRunningA = true;
                animator.SetBool(isRunningHash, true);
            }
            lastTime = Time.time;
        }
    }
}
