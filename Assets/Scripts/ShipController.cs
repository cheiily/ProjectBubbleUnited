using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour {
    public float maxSpeed = 50;
    public float accelerateForce = 10;
    public float accelerationDamping = 0.5f;
    public float rotationDamping = 0f;

    public float mSpeed = 0;
    public Rigidbody mRB;
    public bool mIsAccelerating = false;
    public bool mIsDecelerating = false;
    public Vector2 mMove = Vector2.zero;
    public Vector2 mLook = Vector2.zero;
    //public Vector3 resetPos = transform.position;

    private void Awake() {
        mRB = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // mRB.linearDamping = rotationDamping;
        mRB.angularDamping = rotationDamping;
    }

    // Update is called once per frame
    void Update() {
        if ( mIsAccelerating && mIsDecelerating ) {
            // pass
        } else if ( mIsAccelerating ) {
            mSpeed += (accelerateForce * (1 - accelerationDamping) + mSpeed * accelerationDamping) * Time.deltaTime;
        } else if ( mIsDecelerating ) {
            mSpeed -= (accelerateForce * (1 - accelerationDamping) + mSpeed * accelerationDamping) * Time.deltaTime;
        }

        mSpeed = Mathf.Clamp(mSpeed, -maxSpeed, maxSpeed);

        // rotation speed is in input settings
        transform.Rotate(mMove.y * Time.deltaTime, mMove.x * Time.deltaTime, mLook.x * Time.deltaTime);

        mRB.linearVelocity = mSpeed * transform.forward;
        // mRB.MovePosition(mRB.position + mRB.linearVelocity * Time.deltaTime);

        if (transform.position.y < 60 ) {
            //Debug.Log("SIGMA");
            transform.position = new Vector3 (transform.position.x, transform.position.y + 300, transform.position.z);
        }
    }

    public void OnAccelerate(InputValue ctx) {
        mIsAccelerating = ctx.isPressed;
    }

    public void OnDecelerate(InputValue ctx) {
        mIsDecelerating = ctx.isPressed;
    }

    public void OnMove(InputValue ctx) {
        mMove = ctx.Get<Vector2>();
    }

    public void OnLook(InputValue ctx) {
        mLook = ctx.Get<Vector2>();
    }
}