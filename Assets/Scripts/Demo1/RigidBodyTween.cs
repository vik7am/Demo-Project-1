using UnityEngine;
using DG.Tweening;

namespace Demo1
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidBodyTween : MonoBehaviour
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
            if(Input.GetKeyDown(KeyCode.Space)){
                DoAnimation();
            }
        }

        private void DoAnimation(){
            _rigidbody.DOPath(path, 5, PathType.Linear, PathMode.Full3D, 10, Color.green);
        }
    }
}
