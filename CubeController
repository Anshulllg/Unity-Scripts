using UnityEngine;

public class cubeController : MonoBehaviour
{
    public GameObject anotherObject;
    public float moveSpeed = 3f;
    public float scaleUpFactor = 1.02f;
    public float scaleDownFactor = 0.9f;
    public float rotationSpeed = 2.0f;
    public bool isRotating = false;

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            moveLeft();
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            moveRight();
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            moveForward();
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            moveBackward();
        }
        if(Input.GetKey(KeyCode.S)){
            Scaleobject();
        }
        if(Input.GetKey(KeyCode.D)){
            ScaleDownobject();
        }
        if(Input.GetKey(KeyCode.R)){
            RotateObject();
         
        }
        if(Input.GetKey(KeyCode.T)){
            isRotating = false;
        }

        if(isRotating == true){
            transform.Rotate(Vector3.up *rotationSpeed * Time.deltaTime);
        }
    }

    public void RotateObject(){
        transform.Rotate(Vector3.up *rotationSpeed * Time.deltaTime);
        anotherObject.transform.Rotate(Vector3.up *rotationSpeed * Time.deltaTime);

    }

    // this function is for left movement.
    public void moveLeft(){
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }

    public void moveRight(){
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    public void moveForward(){
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }
    public void moveBackward(){
        transform.position += -Vector3.forward * moveSpeed * Time.deltaTime;
    }

    public void Scaleobject(){
        transform.localScale =  transform.localScale *scaleUpFactor;
    }
    public void ScaleDownobject(){
        transform.localScale =  transform.localScale *scaleDownFactor;
    }

}
