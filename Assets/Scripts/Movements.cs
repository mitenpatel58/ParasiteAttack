using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{


    public float enemies = 3;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float PlayerHealth = 3;
    private Rigidbody rb;
    public Animator animator;
    public Camera cam;
    public FixedJoystick fixedJoystick;
    public float JumpDelayduration;
    public GameObject Axeback;
    public GameObject AxeHand;
    public WeaponScript Wscript;

    public GameObject AxeinHand;
    public GameObject AxeatBack;

    public GameObject objectToCheck;
    public bool hitanim;

    private bool isFirstAnimationPlaying = true;

    AnimatorClipInfo[] myanimatorclipinfo;

    public string currentanimation;

    public static Movements inst;


    void Awake()
    {
        inst = this;
    }

    void Start()
    {



        AxeHand.SetActive(false);
        Axeback.SetActive(true);
        rb = GetComponent<Rigidbody>();
        //hitanim = true;
    }



    void FixedUpdate()
    {
        myanimatorclipinfo = animator.GetCurrentAnimatorClipInfo(0);
        currentanimation = myanimatorclipinfo[0].clip.name;

        // Get input axis values
        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");

        float horizontalInput = fixedJoystick.Horizontal;
        float verticalInput = fixedJoystick.Vertical;

        // Calculate movement direction based on camera
        Vector3 cameraForward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = cameraForward * verticalInput + cam.transform.right * horizontalInput;

        if (currentanimation != "Standing Melee Attack Horizontal" && currentanimation != "Your Animation Name")
        {
            rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        }

        //for Player Health check
        if (PlayerHealth <= 0)
        {
            ScreenManager.inst.ShowNextScreen(ScreenType.GameOverScreen);
        }

        //for enemiescount
        if(enemies <= 0 )
        {
            ScreenManager.inst.ShowNextScreen(ScreenType.GameOverScreen);
        }




        animator.SetFloat("Velocity Z", verticalInput);
        animator.SetFloat("Velocity X", horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && verticalInput > 0f)
        {

            animator.SetTrigger("RunningJump");
            Jump();

        }


        if (Input.GetKeyDown(KeyCode.Space) && verticalInput < 0f)
        {
            animator.SetTrigger("BackwardsJump");

        }

        if (Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(horizontalInput) > 0))
        {
            StartCoroutine(JumpDelay());
            animator.SetTrigger("isJumping");
        }

        // Check if the player is playing the specific animation and stop moving
        if (currentanimation == "Unarmed Equip Underarm" ||
            currentanimation == "Standing Disarm Underarm")
        {
            Debug.Log("animation success");
            rb.velocity = Vector3.zero;
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && verticalInput == 0 && horizontalInput == 0)
        {
            StartCoroutine(JumpDelay());
            animator.SetTrigger("isJumping");
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHand" && hitanim == true)
        {
            Debug.Log("Hand collided");
            animator.SetTrigger("Hitted");
            PlayerHealth--;
        }
    }

    public void OnEnable()
    {
        if (objectToCheck.activeInHierarchy)
        {
            Debug.Log("Equiped Weapon");
            animator.SetTrigger("AxeAttack");
            hitanim = false;

        }
        else
        {
            Debug.Log("Unequiped Weapon");
            animator.SetTrigger("Punch");
            hitanim = false;

        }

    }




    public void SwitchWp()
    {
        if (isFirstAnimationPlaying)
        {
            Debug.Log("Equip");
            animator.SetTrigger("Equip");
            isFirstAnimationPlaying = false;
        }
        else
        {
            Debug.Log("Unequip");
            animator.SetTrigger("Unequip");
            isFirstAnimationPlaying = true;
        }
    }


    public void JumpBtn()
    {
        if (fixedJoystick.Horizontal == 0 && fixedJoystick.Vertical == 0)
        {
            StartCoroutine(JumpDelay());
            animator.SetTrigger("isJumping");
        }

        if (fixedJoystick.Vertical < 0f)
        {
            animator.SetTrigger("BackwardsJump");
        }
        if (fixedJoystick.Vertical > 0f)
        {
            animator.SetTrigger("RunningJump");
            Jump();
        }
    }



    public void AxeSwitch()
    {
        AxeHand.SetActive(true);
        Axeback.SetActive(false);
    }

    public void AxeSwitch1()
    {
        AxeHand.SetActive(false);
        Axeback.SetActive(true);
    }



    void Hitting()
    {
        Wscript.trigger = true;
    }

    void NotHitting()
    {
        Wscript.trigger = false;
    }





    public void Jump()
    {
        rb.velocity += Vector3.up * jumpForce;

    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(JumpDelayduration);

        Jump();
    }
}
