using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    Animator animator;
    public GameObject target;
    public GameObject parent;

    // ChangeTextHealth changeTextHealth;
    // GameObject changeTextHealthObject;

    public int movementSpeed=15;
    private int childCount;
    private string currentState;
    private bool walkingFlag=false;
    private bool explodeFlag=false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        target = GameObject.Find("Body");
        parent = transform.parent.gameObject;
        childCount = parent.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
        if((parent.transform.childCount != childCount || RaycastCheck() || walkingFlag) && !explodeFlag){
            ChangeAnimationState("walk");
            walkingFlag=true;
            Walking();
        }
    }

    private bool RaycastCheck(){
        //Ray ray = GameObject.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.forward * 200,Color.green);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), transform.forward, out hit, 200)) {   
            if(hit.transform.name.Contains("Body"))
                return true;
        }
        return false;
    }

    public void ChangeAnimationState(string newState){
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
            // GameObject player = other.gameObject.transform.parent.gameObject;
            // changeTextHealthObject=player;
            // changeTextHealth = changeTextHealthObject.GetComponent<ChangeTextHealth>();
            // changeTextHealth.ChangeHealthNumberText(100,player);
        }
        explodeFlag=true;
        ChangeAnimationState("attack01");
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
