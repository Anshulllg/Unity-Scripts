using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float moveSpeed = 3f;
    public GameObject targetObject; 
    
    private Transform target;

    void Start()
    {

        if (targetObject == null)
        {
 
            GameObject diamond = GameObject.FindGameObjectWithTag("Diamond");
            if (diamond != null)
            {
                targetObject = diamond;
            }
            else
            {
                Debug.LogError("Cannot find target object. Please assign it directly or ensure an object with tag 'Diamond' exists.");
            }
        }

        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0; 
            
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f * Time.deltaTime);
            }
            
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
