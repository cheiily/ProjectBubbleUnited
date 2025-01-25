using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace {
    public class Enemy : MonoBehaviour {
        public float TTL = 15;

        public TransparentEnemyMaterialsPreset materialPreset;
        public float mMaterialAlpha = 1.0f;
        public bool mFadeStarted = false;
        public bool mUseDeadMaterial = false;

        public MeshRenderer mesh;

        public void OnCollisionEnter(Collision other) {
            if ( mFadeStarted )
                return;
            var mats = mesh.materials;
            mats[0] = materialPreset.deadMaterials[0];
            mesh.materials = mats;
            mUseDeadMaterial = true;
        }

        public void Update() {
            TTL -= Time.deltaTime;
            if (TTL <= 0 & !mFadeStarted) {
                GetComponent<Animator>().enabled = true;
                mesh.materials = materialPreset.materials.ToArray();
                if (mUseDeadMaterial) {
                    var mats = mesh.materials;
                    mats[0] = materialPreset.deadMaterials[1];
                    mesh.materials = mats;
                }
            }

            if (mFadeStarted) {
                foreach (var material in mesh.materials) {
                    var color = material.color;
                    color.a = mMaterialAlpha;
                    material.color = color;
                }
            }
        }

        public void DeferredDestroy() {
            Destroy(gameObject);
        }
    }
}