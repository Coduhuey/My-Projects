using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor"); //Layer.GetMask() the layered gameobject of floor as the layermask of type int
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); //with Input.GetAxisRaw() it doesn't move at varying speeds, just the top speed
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);

        Turning();

        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v); //.set makes float values into a vector3

        movement = movement.normalized * speed * Time.deltaTime; //movement.normalized makes it so that no matter where you turn the speed is the same

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //a ray is called, Camera.main uses the main camera and .ScreenPointToRay makes a ray from the camera guide to the specified point which would be the input of the mouse position, Input.mousePosition

        RaycastHit floorHit; //information of where the rays hit is sent to the RaycastHit variables sent out from the Physics.Raycast functions

        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position; //takes the position of the floorHit's point

            playerToMouse.y = 0f;
            //FORGOT
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse); //Quaternion.LookRotation makes the object look in the direction the vector3 orginated from it is pointing

            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool Walking = h != 0f || v != 0f; //if h or v is not equal to 0f then walking is true;

        anim.SetBool("IsWalking", Walking); //anim.SetBool first needs the bool event to be called and a bool variable to compare it to
    }
}
