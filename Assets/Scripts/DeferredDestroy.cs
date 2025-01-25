using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace {
    public class DeferredDestroy : MonoBehaviour {
        public float TTL = 15;
        public bool useFade = true;
        public bool useAnimator = true;

        public float defaultFadeTime = 1.0f;
        public float mDefaultFadeTimer = 0.0f;

        public float mMaterialAlpha = 1.0f;
        public bool mFadeStarted = false;

        public List<Material> fadeTransparentMaterials;
        public MeshRenderer mesh;

        private void Awake() {
            if (fadeTransparentMaterials.Count == 0) {
                useFade = false;
            }

            Animator animator;
            TryGetComponent(out animator);
            if (animator == null) {
                useAnimator = false;
            }
        }

        public void Update() {
            TTL -= Time.deltaTime;
            if (TTL <= 0 & !mFadeStarted) {
                if (useAnimator)
                    GetComponent<Animator>().enabled = true;
                if (useFade) {
                    mesh.materials = fadeTransparentMaterials.ToArray();
                    mFadeStarted = true;
                }
                if (!useFade && !useAnimator)
                    DoDestroy();
            }

            if (useFade && mFadeStarted) {
                mDefaultFadeTimer += Time.deltaTime;
                if ( !useAnimator ) {
                    mMaterialAlpha = 1 - mDefaultFadeTimer / defaultFadeTime;
                }
                foreach (var material in mesh.materials) {
                    var color = material.color;
                    color.a = mMaterialAlpha;
                    material.color = color;
                }

                if (mDefaultFadeTimer >= defaultFadeTime) {
                    DoDestroy();
                }
            }
        }

        public void DoDestroy() {
            Destroy(gameObject);
        }
    }
}