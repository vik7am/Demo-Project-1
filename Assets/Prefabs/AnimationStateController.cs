using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo1
{
    public class AnimationStateController : MonoBehaviour
    {
        Animator animator;
        int isWalkingHash;
        int isRunningHash;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("isWalking");
            isRunningHash = Animator.StringToHash("isRunning");
        }

        // Update is called once per frame
        void Update()
        {
            bool isWalking = animator.GetBool(isWalkingHash);
            bool isRunning = animator.GetBool(isRunningHash);
            bool forwardPressed = Input.GetKey(KeyCode.W);
            bool runPressed = Input.GetKey(KeyCode.LeftShift);
            if(!isWalking && forwardPressed){
                animator.SetBool(isWalkingHash, true);
            }
            if(isWalking && !forwardPressed){
                animator.SetBool(isWalkingHash, false);
            }
            if(!isRunning && (forwardPressed && runPressed)){
                animator.SetBool(isRunningHash, true);
            }
            if(isRunning && (!forwardPressed || !runPressed)){
                animator.SetBool(isRunningHash, false);
            }
        }
    }
}
