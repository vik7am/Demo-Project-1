using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Demo1
{
    public class TransformTween : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3[] path;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start() {
            path = new Vector3[4];
            for(int i=0; i<transform.childCount; i++){
                path[i] = transform.GetChild(i).transform.position;
            }
        }

        private void Update() {
            // if(Input.GetKeyDown(KeyCode.Space)){
            //     DoSequenceAnimation();
            // }
        }

        private void DoSequenceAnimation(){
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveX(4, 2));
            sequence.Append(transform.DORotate(new Vector3(0, 90, 0), 2));
            sequence.PrependInterval(1);
            sequence.Insert(0, transform.DOScale(new Vector3(3,3,3), sequence.Duration()));
        }

        private void DoAnimation(){
            
            transform.DORotate(new Vector3(45, 0, 0), 1);
            //print(transform.rotation.eulerAngles);
            // transform.DOPath(path, 5, PathType.Linear, PathMode.Full3D, 10, Color.green)
            //     .SetSpeedBased(true)
            //     .SetEase(Ease.Linear);
            
        }
    }
}
