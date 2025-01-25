using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace {
    public class Enemy : MonoBehaviour {
        public float TTL = 15;

        public TransparentEnemyMaterialsPreset materialPreset;
        public float materialAlpha = 1.0f;
        public bool fadeStarted = false;

        public MeshRenderer mesh;

        private void Start() {
            mesh = GetComponentInChildren<MeshRenderer>();
        }

        public void Update() {
            TTL -= Time.deltaTime;
            if (TTL <= 0 & !fadeStarted) {
                GetComponent<Animator>().enabled = true;
                mesh.materials = materialPreset.materials.ToArray();
                fadeStarted = true;
            }

            if (fadeStarted) {
                foreach (var material in mesh.materials) {
                    var color = material.color;
                    color.a = materialAlpha;
                    material.color = color;
                }
            }
        }

        public void DeferredDestroy() {
            Destroy(gameObject);
        }
    }
}