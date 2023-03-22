using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerController playerActionsAsset;
    private InputAction move;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float jumpForce = 5f;
    private float maxSpeed = 5f;

    private Vector3 forceDireccion = Vector3.zero;

    [SerializeField]
    private Camera playerCamera;

    public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerActionsAsset = new PlayerController();
        anim = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerActionsAsset.Player.Jump.started += Dojump;
       // playerActionsAsset.Player.Attack.started += DoAttack;
        move = playerActionsAsset.Player.Move;
        playerActionsAsset.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAsset.Player.Jump.started -= Dojump;
       // playerActionsAsset.Player.Attack.started -= DoAttack;
        playerActionsAsset.Player.Disable();
    }

    private void FixedUpdate()
    {
        forceDireccion += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDireccion += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDireccion, ForceMode.Impulse);
        forceDireccion = Vector3.zero;
        if (rb.velocity.y < 0f)
        {
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }
        LookArt();
    }

    private void LookArt()
    {

        Vector3 direcction = rb.velocity;
        direcction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direcction.sqrMagnitude > 0.1f)
        {
            this.rb.rotation = Quaternion.LookRotation(direcction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }

    }


    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    private void Dojump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            forceDireccion += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DoAttack(InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Attack");
    }
}
