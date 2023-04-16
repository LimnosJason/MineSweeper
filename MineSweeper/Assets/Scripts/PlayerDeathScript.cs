using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    Animator animator;
    Animator playerAnimator;

    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;

    SettingsScript settingsScript;
    [SerializeField] GameObject settingsScriptObject;

    [SerializeField] Camera animationCamera;

    private string currentState;
    // Start is called before the first frame update

    

    void Awake(){
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
        settingsScript = settingsScriptObject.GetComponent<SettingsScript>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();    
        playerAnimator = playerStatisticsScriptObject.GetComponent<Animator>();    
    }
    
    void Update(){
        if(playerStatisticsScript.GetPlayerHealth()==0){
            PlayerDeath();
        }
    }

    public void PlayerDeath(){
        settingsScript.FreezeAndRemoveAim();
        StartCoroutine(ExampleCoroutine());
    }

    private void ChangePenguinsAnimationState(string newState, Animator anim){
        currentState=newState;
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            anim.Play(newState);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        playerAnimator.enabled = true;
        ChangePenguinsAnimationState("DeadDypCamera", playerAnimator);
        yield return new WaitForSeconds(0.3f);
        animationCamera.cullingMask |= 1 << LayerMask.NameToLayer("Character");
        ChangePenguinsAnimationState("Dyp_death", animator);
    }
}
