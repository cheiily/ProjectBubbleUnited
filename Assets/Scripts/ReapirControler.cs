using UnityEngine;
using UnityEngine.InputSystem;

public class ReapirControler : MonoBehaviour
{
    public float bulletVelocity = 50;
    public float deltaShoot = 0.5f;

    public float mTimer = 0;
    public bool mIsReapiring = false;

    public void OnRepair(InputValue ctx)
    {
        mIsReapiring = ctx.isPressed;
    }

    public void Update()
    {
        mTimer += Time.deltaTime;
        if (mIsReapiring && mTimer >= deltaShoot)
        {
            mTimer = 0;
            
        }
    }
}
