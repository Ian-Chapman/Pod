using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 5;
    [SerializeField]
    float runSpeed = 10;
    //[SerializeField]
    //float jumpForce = 5;

    //components
    private PlayerController playerController;
    Rigidbody rigidbody;
    Animator playerAnimator;
    public GameObject followTarget;

    //references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;

    public float aimSensitivity = 1;

    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("IsJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        playerAnimator = GameObject.Find("Pod").GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();

        if (!GameManager.instance.cursorActive)
        {
            AppEvents.InvokeMouseCursorEnable(false);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ///aiming/Looking
        ///horizontal rotation
        followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);
        //verical rotation
        followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.right);

        //Clamping camera angles
        var angles = followTarget.transform.localEulerAngles;
        angles.z = 0;

        var angle = followTarget.transform.localEulerAngles.x;

        if (angle > 180 && angle < 300)
        {
            angles.x = 300;
        }
        else if (angle < 180 && angle > 70)
        {
            angles.x = 70;
        }

        followTarget.transform.localEulerAngles = angles;

        //rotate the player rotation based on the look transform
        transform.rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);

        followTarget.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

        if (!(inputVector.magnitude > 0))
        {
            moveDirection = Vector3.zero;
        }

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;
        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

        transform.position += movementDirection;


    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        playerAnimator.SetFloat(movementXHash, inputVector.x);
        playerAnimator.SetFloat(movementYHash, inputVector.y);
    }

    public void OnRun(InputValue value)
    { 
        playerController.isRunning = value.isPressed;
    }

    public void OnJump(InputValue value)
    {

        playerController.isJumping = value.isPressed;
        rigidbody.AddForce((transform.up + moveDirection) * walkSpeed, ForceMode.Impulse);
        //playerAnimator.SetBool(isJumpingHash, playerController.isJumping);
    }

    public void OnDive(InputValue value)
    {
        playerController.isDiving = value.isPressed;
        rigidbody.AddForce((-transform.up + moveDirection) * (runSpeed * 2), ForceMode.Impulse);
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }



    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Ground") && !playerController.isJumping)
        {
            return;
        }

        if (other.gameObject.tag == "Ground")
        {
            playerController.isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!other.gameObject.CompareTag("Water Surface") && !playerController.isJumping)
        //{
        //    return;
        //}

        if (other.gameObject.tag == "Water Surface")
        {
            playerController.isJumping = false;
            //rigidbody.useGravity = false;
        }
    }
}
