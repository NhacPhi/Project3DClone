using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float runSpeed = 5f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private float gravityValue = -9.8f;
    [SerializeField]
    private float jumpHeight = 1.0f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField]
    private Camera thirdFollowCamera;

    [SerializeField]
    public Animator animatorPlayer;

    private Vector3 movementDirection;

    //public ManagerCanvas UIGamePlay;

    public StartRotate start;

    float VelocityVetical = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }

    void PlayerControl()
    {
        groundedPlayer = playerController.isGrounded;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        animatorPlayer.SetFloat("VelocityY", vertical);

        animatorPlayer.SetFloat("VelocityX", horizontal);

        Vector3 movementInput = Quaternion.Euler(0, thirdFollowCamera.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0, vertical);
        movementDirection = movementInput.normalized;
        // need to improve the jump, it's so copium right now
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            animatorPlayer.SetTrigger("Jump");
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue); // this fomula from unity document, no idea why
            VelocityVetical = 5;
        }

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) /*&& Vertical != 0*/)
        {
            playerController.Move(movementDirection * runSpeed * Time.deltaTime);
            if (vertical != 0)
                animatorPlayer.SetFloat("VelocityY", vertical * 2);
            if (horizontal != 0)
                animatorPlayer.SetFloat("VelocityX", horizontal * 2);
        }
        else
        {
            playerController.Move(movementDirection * speed * Time.deltaTime);
        }


        //playerVelocity.y += gravityValue * Time.deltaTime;

        //playerController.Move(playerVelocity);


        // handle gravity
        VelocityVetical = VelocityVetical - 9.8f * Time.deltaTime;
        if (VelocityVetical < -9.8f)
        {
            VelocityVetical = -9.8f;
        }
        Vector3 verticalSpeed = new Vector3(0, VelocityVetical * Time.deltaTime, 0);
        playerController.Move(verticalSpeed);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "Machine")
        {
            if (movementDirection.sqrMagnitude == 0)
            {
                //UIGamePlay.enabled = true;
                animatorPlayer.SetBool("IsRepair", true);
                //UIGamePlay.SetActiveCanvas(true);
            }

            else
            {
                animatorPlayer.SetBool("IsRepair", false);
                //UIGamePlay.SetActiveCanvas(false);
            }

        }
        else
        {
            animatorPlayer.SetBool("IsRepair", false);
            //UIGamePlay.SetActiveCanvas(false);
        }
        if (hit.gameObject.tag == "Stunned")
        {
            animatorPlayer.SetBool("IsStunned", true);
            start.ActiveRoate(true);
        }
        else
        {
            animatorPlayer.SetBool("IsStunned", false); 
            start.ActiveRoate(false);
        }
        if (hit.gameObject.tag == "Trap")
        {
            animatorPlayer.SetBool("IsHurting", true);
            //UIGamePlay.SetActiveCavasTrap(true);
        }
        else
        {
            animatorPlayer.SetBool("IsHurting", false);
            //UIGamePlay.SetActiveCavasTrap(false);
        }
    }
}
