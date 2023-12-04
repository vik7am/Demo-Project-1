using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Demo1
{
    public class CameraTween : MonoBehaviour
    {
        Camera _camera;
        private void Start() {
            _camera = Camera.main;
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space)){
                DoAnimation();
            }
        }

        private void DoAnimation(){
            _camera.DOShakePosition(2, 1, 2, 20, false, ShakeRandomnessMode.Harmonic);
        }
    }
}
