using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Movement
//This script requires the component Character controller, it will create a charater controller when the script is attached to a game object and won't allow the componet to be removed
[RequireComponent(typeof (CharacterController))]
[AddComponentMenu("Intro PRG/RPG/Player/Movement")]
public class Movement : MonoBehaviour 
{
    #region Variables
    [Header ("PLAYER MOVEMENT")]
    [Space(5)]
    [Header("Characters MoveDirection")]
    //vector3 called moveDirection
    public Vector3 moveDirection;
    //we will use this to apply movement in worldspace
    //private CharacterController charC
    private CharacterController _characterController;
    // The type of data being interactive with is a character controller, this is the reference name for the charater controller 
    [Header("Character Variables")]
    //public float variables jumpSpeed, speed, gravity
    public float jumpSpeed = 10;
    public float speed = 5;
    public float gravity = 20;
    public static bool canMove;

    #endregion
    #region Start
    private void Start()
    {
        canMove = true;
        _characterController = this.GetComponent<CharacterController>(); 
    }
  
    #endregion
    #region Update
    private void Update()
    {     //if our character is grounded
        if (canMove)
        {
            if (_characterController.isGrounded)
            {
                //we are able to move in game scene meaning
                //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                //moveDir is transformed in the direction of our moveDir
                moveDirection = transform.TransformDirection(moveDirection);
                //our moveDir is then multiplied by our speed
                moveDirection *= speed;
                //we can also jump if we are grounded so
                //in the input button for jump is pressed then
                if (Input.GetButton("Jump"))
                    //our moveDir.y is equal to our jump speed }
                    moveDirection.y = jumpSpeed;
            }
            //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
            moveDirection.y -= gravity * Time.deltaTime;
            //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
            _characterController.Move(moveDirection * Time.deltaTime);
        }
    }
    #endregion
}










