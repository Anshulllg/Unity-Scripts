using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    private Rigidbody rb;
    private bool targetHit;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(targetHit==true){
            return;
        }else{
            targetHit = true;
        }

        if(collision.gameObject.GetComponent<Enemy>()!= null){
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }

    }
}
