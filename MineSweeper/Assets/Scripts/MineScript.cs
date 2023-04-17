using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    Animator animator;
    public GameObject target;
    public GameObject parent;
    PlayerStatisticsScript playerStatisticsScript;
    [SerializeField] GameObject playerStatisticsScriptObject;
    [SerializeField] GameObject mineHitBox;
    
    Collider mineHitBoxCollider;
    GameObject skyMineCounterCanvas;
    GameObject flagImage;
    GameObject mineCounterText;

    public GameObject deadTextureGameObject, normalTextureGameObject;

    public int movementSpeed=15;
    private int childCount;
    private string currentState;
    private bool walkingFlag=false;
    private bool explodeFlag=false;

    void Awake(){
        playerStatisticsScript = playerStatisticsScriptObject.GetComponent<PlayerStatisticsScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        target = GameObject.Find("Body");
        parent = transform.parent.gameObject;
        childCount = parent.transform.childCount;

        skyMineCounterCanvas=(transform.parent.gameObject).transform.Find("Sky MineCounter Canvas(Clone)").gameObject;
        flagImage=skyMineCounterCanvas.transform.Find("Flag Image").gameObject;
        
        mineHitBoxCollider=mineHitBox.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
        if(!flagImage.activeSelf){
            Debug.Log(flagImage.activeSelf);
            transform.LookAt(target.transform);
            animator.enabled=true;
            mineHitBoxCollider.enabled=true;
            normalTextureGameObject.SetActive(true);
            deadTextureGameObject.SetActive(false);
            if((parent.transform.childCount != childCount || RaycastCheck() || walkingFlag) && !explodeFlag){
                movementSpeed=15;
                ChangeAnimationState("walk");
                walkingFlag=true;
                Walking();
            }
        }
        else{
            animator.enabled=false;
            mineHitBoxCollider.enabled=false;
            movementSpeed=0;
            normalTextureGameObject.SetActive(false);
            deadTextureGameObject.SetActive(true);
        }
    }

    private bool RaycastCheck(){
        //Ray ray = GameObject.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.forward * 200,Color.green);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.forward, out hit, 200)) {   
            if(hit.transform.name.Contains("Dyp"))
                return true;
        }
        return false;
    }

    private void ChangeAnimationState(string newState){
        currentState=newState;
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName(currentState))
            animator.Play(newState);
    }

    void Walking(){
        if(walkingFlag){
            transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * movementSpeed);
        }
    }

    public void Explode(Collider other){
        walkingFlag=false;
        if(!explodeFlag){
            playerStatisticsScript.SetPlayerHealth(playerStatisticsScript.GetPlayerHealth() - 100);
        }
        explodeFlag=true;
        ChangeAnimationState("attack01");
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
