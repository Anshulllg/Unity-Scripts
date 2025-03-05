using UnityEngine;

public class AnimationsScript : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator =  GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Q)){
            animator.SetBool("isrunning",true);
        }
        if(Input.GetKey(KeyCode.W)){
            animator.SetBool("isrunning",false);
        }
    }
}
