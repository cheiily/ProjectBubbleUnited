using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour {
    public float accelerateForce = 10;
    public float accelerationDamping = 0.5f;
    public float rotationDamping = 0f;

    public float mSpeed = 0;
    // public
    public Rigidbody mRB;
    public bool mIsAccelerating = false;
    public bool mIsDecelerating = false;
    public Vector2 mMove = Vector2.zero;

    private void Awake() {
        mRB = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        mRB.linearDamping = rotationDamping;
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

        // rotation speed is in input settings
        transform.Rotate(mMove.y * Time.deltaTime, mMove.x * Time.deltaTime, 0);

        mRB.linearVelocity = mSpeed * transform.forward;
    }

    public void OnAccelerate(InputValue ctx) {
        mIsAccelerating = ctx.isPressed;
    }

    public void OnDecelerate(InputValue ctx) {
        mIsDecelerating = ctx.isPressed;
    }

    public void OnMove(InputValue ctx) {
        Debug.Log(ctx.Get<Vector2>());

        mMove = ctx.Get<Vector2>();


        // mRB.rotation = Quaternion.Lerp(mRB.rotation, Quaternion.AngleAxis(ctx.Get<Vector2>().x, mRB.transform.up) * Quaternion.AngleAxis(ctx.Get<Vector2>().y, mRB.transform.right), rotationDamping);

    }
}