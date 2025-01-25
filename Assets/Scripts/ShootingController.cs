using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace {
    public class ShootingController : MonoBehaviour {
        public GameObject spawningAnchor;
        public GameObject bulletPrefab;
        public float bulletVelocity = 50;
        public float deltaShoot = 0.5f;

        public float mTimer = 0;
        public bool mIsShooting = false;

        public void OnShoot(InputValue ctx) {
            mIsShooting = ctx.isPressed;
        }

        public void Update() {
            mTimer += Time.deltaTime;
            if ( mIsShooting && mTimer >= deltaShoot ) {
                mTimer = 0;
                var bullet = Instantiate(bulletPrefab, spawningAnchor.transform.position, spawningAnchor.transform.rotation * Quaternion.Euler(90, 0, 0));
                // bullet.transform.Rotate(spawningAnchor.transform.forward);
                // bullet.transform.LookAt(spawningAnchor.transform.position);
                // bullet.transform.SetLocalPositionAndRotation(bullet.transform.localPosition, Quaternion.Euler(spawningAnchor.transform.forward));
                var bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.linearVelocity = spawningAnchor.transform.forward * bulletVelocity;
            }
        }
    }
}