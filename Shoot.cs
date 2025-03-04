using UnityEngine;

public class Shoot : MonoBehaviour
{   
    public Transform cam;
    public Transform attackpoint;
    public GameObject Bullets;

    public int totalBullets;
    public float throwForce;
    public float throwUpwardForce;
    public float throwCoolDown;
    public KeyCode throwKey = KeyCode.Mouse0;
    public bool ReadyToThrow ;

    void Start()
    {
        ReadyToThrow = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throwKey) && ReadyToThrow && totalBullets>0){
            throwbullets();
        }   
    }
    private void throwbullets(){
        ReadyToThrow = false;
        GameObject projectile = Instantiate(Bullets, attackpoint.position, cam.rotation);
        Rigidbody projectionRB = projectile.GetComponent<Rigidbody>();

        Vector3 ForceDirection = cam.transform.forward;
        RaycastHit hit ;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 600f)){
            ForceDirection = (hit.point - attackpoint.position).normalized;
        }
        
        Vector3 forceToAdd = ForceDirection *throwForce + transform.up * throwUpwardForce;
        projectionRB.AddForce(forceToAdd, ForceMode.Impulse);
        totalBullets = totalBullets -1;
       
       Invoke(nameof(ResetThrow), throwCoolDown);
    }
    private void ResetThrow(){
        ReadyToThrow = true;
    }


}
