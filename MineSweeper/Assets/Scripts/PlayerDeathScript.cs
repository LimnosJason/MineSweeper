using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    Animator animator;

    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;

    private string currentState;
    // Start is called before the first frame update

    void Awake(){
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();    
    }
    
    void Update(){
        if(playerStatisticsScript.GetPlayerHealth()==0){
            PlayerDeath();
        }
    }

    public void PlayerDeath(){
        StartCoroutine(ExampleCoroutine());
    }

    private void ChangePenguinsAnimationState(string newState){
        currentState=newState;
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            animator.Play(newState);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        ChangePenguinsAnimationState("Dyp_death");
    }
}
