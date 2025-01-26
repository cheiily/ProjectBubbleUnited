using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace DefaultNamespace {
    public class Enemy : MonoBehaviour {
        public float TTL = 15;
        public float MaxTTL = 120;

        public TransparentEnemyMaterialsPreset materialPreset;
        public float mMaterialAlpha = 1.0f;
        public bool mFadeStarted = false;
        public bool mUseDeadMaterial = false;
        public bool mStartedTTLFade = false;

        public MeshRenderer mesh;
        public GameObject wyrwaPrefab;

        public GameObject boom; 

        [SerializeField]
        private float demage;

        public void OnCollisionEnter(Collision other) {
            if(other.gameObject.layer == LayerMask.NameToLayer("Bubble"))
            {
                other.gameObject.GetComponent<SphereScript>().growSpeed -= demage;
                GameObject point = Instantiate(wyrwaPrefab, other.gameObject.transform) as GameObject;
                point.transform.position = other.contacts[0].point;
                //point.transform.LookAt(other.gameObject.transform);
                other.gameObject.GetComponent<SphereScript>().wyrwa.Add(point);
                boom.SetActive(false);
                mStartedTTLFade = true;
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Bullets")) {
                // play particles
                // play sound
                Destroy(gameObject);
            }

            if ( mFadeStarted )
                return;
            var mats = mesh.materials;
            mats[0] = materialPreset.deadMaterials[0];
            mesh.materials = mats;
            mUseDeadMaterial = true;
        }

        public void Update() {
            if (mStartedTTLFade) {
                TTL -= Time.deltaTime;
            }
            MaxTTL -= Time.deltaTime;
            if ( (TTL <= 0 || MaxTTL < 0) & !mFadeStarted) {
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