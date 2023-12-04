using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Demo1
{
    public class HammerTween : MonoBehaviour
    {
        [SerializeField] private Vector3 endMoveValue;
        [SerializeField] private Vector3 endRotationValue;
        [SerializeField] private Vector3 endScaleValue;
        [SerializeField] private Vector3 endMoveValue2;
        [SerializeField] private Vector3 endRotationValue2;
        [SerializeField] private Vector3 endScaleValue2;
        private GameObject child;
        private void Start() {
            child = transform.GetChild(0).gameObject;
        }
        
        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space))
                RunAnimation();
        }

        private void RunAnimation(){
            child.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            sequence.Join(transform.DOMove(endMoveValue, 1).SetRelative(true))
                .Join(transform.DORotate(endRotationValue, 1, RotateMode.FastBeyond360).SetRelative(true))
                .Join(transform.DOScale(endScaleValue, 1))
                .Append(transform.DOMove(endMoveValue2, 0.5f).SetRelative(true))
                .Join(transform.DORotate(endRotationValue2, 0.5f, RotateMode.FastBeyond360).SetRelative(true))
                .Join(transform.DOScale(endScaleValue2, 0.5f))
                .OnComplete(()=>{child.SetActive(false);});
        }
    }
}
