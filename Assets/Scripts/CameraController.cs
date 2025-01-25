using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace {
    public class CameraController : MonoBehaviour {
        public Transform target;
        public Transform anchor;
        public float smoothTime;

        public Vector3 mVelocity;
        public Vector3 mOffset;

        private void Awake() {
            // mOffset = anchor.position - target.position;
            mOffset = new Vector3(0, 0, -10);
        }

        public void Update() {
            var targetPos = target.position + mOffset;
            // transform.position = Vector3.Lerp(transform.position, anchor.position, 0.5f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref mVelocity, smoothTime);
        }

    }
}