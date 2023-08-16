using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObject : MonoBehaviour,IHitAgent
{

    protected PlayerStateMachine playerStateMachine;
    //public CharacterController controller;
    public Rigidbody rbbody;
    public Collider playerCollider;

    public Animator playerAnimator;
    public Transform mainCameraTransform { get; private set; }
    public CinemachineFreeLook freeLookCamera;
    public PlayerInputAction inputAction { get;private set; }

    public static PlayerObject instance;

    public float maxHealth = 1000;
    public float currentHealth;

   // public GreatSwordAttackDetecion detecion;

    //public TestHit testHit;

    //public Dictionary<string, Transform> characterDic = new Dictionary<string, Transform>();
    //public List<Transform> characterList = new List<Transform>();

    public Transform LookAt;

    public bool isOnSlide = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        freeLookCamera = FindObjectOfType<CinemachineFreeLook>();
        //controller = GetComponent<CharacterController>();
        rbbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();

        inputAction = new PlayerInputAction();
        inputAction.Enable();
        playerAnimator = GetComponent<Animator>();

        LookAt = transform.Find("LookAt");
        freeLookCamera.LookAt = LookAt;
        freeLookCamera.Follow = LookAt;

/*        playerXingAnimator = XingTransform.GetComponent<Animator>();
        playerMarchAnimator = MarchTransform.GetComponent<Animator>();*/

        //playerAnimator = playerXingAnimator;
        //playerAnimator.runtimeAnimatorController = playerXingAnimator.runtimeAnimatorController;
        //playerAnimator.avatar = playerXingAnimator.avatar;
        //instance = gameObject.GetComponent<PlayerObject>();

        playerStateMachine = new PlayerStateMachine();
        playerStateMachine.Init(this);
        
        instance = this;

        InputManager.GetInstance();

        //detecion = new GreatSwordAttackDetecion();
        //testHit = new TestHit();

        currentHealth = 1000;
        //playerCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerStateMachine.Update();
        //testHit.GetDamage(new AttackValueData(), 1f);
        //print(playerCollider.isTrigger); 
    }

    public void GetDamage(int dmg, float dir)
    {
        if (isOnSlide) return;
        print(currentHealth);
        currentHealth = Mathf.Max(0, currentHealth - 10);
        if(currentHealth == 0)
        {
            playerStateMachine.ChangeState(E_PlayerState.DeadState);
        }
        else
        {
            InputManager.GetInstance().playerState = E_PlayerState.HitState;
            EventCenter.GetInstance().EventTrigger(E_EventC.SwitchStateNow);
        }
    }
}
