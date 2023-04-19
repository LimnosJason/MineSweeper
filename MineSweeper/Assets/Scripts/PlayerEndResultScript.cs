using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndResultScript : MonoBehaviour
{
    static Animator animator;
    Animator playerAnimator;

    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;

    static SettingsScript settingsScript;
    [SerializeField] GameObject settingsScriptObject;

    PlayerCamera playerCamera;
    [SerializeField] Camera animationCamera;

    PlayerMovement playerMovement;
    [SerializeField] GameObject playerMovementObject;

    TimerScript timerScript;
    [SerializeField] GameObject timerScriptObject;

    private string currentState;
    // Start is called before the first frame update

    

    void Awake(){
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
        playerCamera = animationCamera.GetComponent<PlayerCamera>();
        playerMovement = playerMovementObject.GetComponent<PlayerMovement>();
        timerScript = timerScriptObject.GetComponent<TimerScript>();
        settingsScript = settingsScriptObject.GetComponent<SettingsScript>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();    
        playerAnimator = playerStatisticsScriptObject.GetComponent<Animator>();    

        timerScript.StartTimer();
        playerMovement.StartMovement();
        playerCamera.StartCamera();
    }
    
    void Update(){
        if(playerStatisticsScript.GetPlayerHealth()==0){
            timerScript.StopTimer();
            playerMovement.StopMovement();
            playerCamera.StopCamera();
            PlayerDeath();
        }
    }

    public void PlayerDeath(){
        settingsScript.FreezeAndRemoveAim();
        StartCoroutine(LoseCoroutine());
    }

    public void PlayerWin(){
        settingsScript.FreezeAndRemoveAim();
        // playerAnimator.enabled = true;
        animationCamera.cullingMask |= 1 << LayerMask.NameToLayer("Character");
        ChangePenguinsAnimationState("Dyp_jump_01", animator);
    }

    private void ChangePenguinsAnimationState(string newState, Animator anim){
        currentState=newState;
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            anim.Play(newState);
    }

    IEnumerator LoseCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        playerAnimator.enabled = true;
        ChangePenguinsAnimationState("DeadDypCamera", playerAnimator);
        yield return new WaitForSeconds(0.3f);
        animationCamera.cullingMask |= 1 << LayerMask.NameToLayer("Character");
        ChangePenguinsAnimationState("Dyp_death", animator);
    }
}