using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;
    public float touchPaddleSpeed = 0.1f;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    public Text debugText;

    // Update is called once per frame
    void Update()
    {
        //Horizontal gets from arrow, a OR d and joystick movement
        //We're adding our speed to that.

        //float xPos = transform.position.x + (Input.GetAxis("Mouse X") * paddleSpeed);
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);

        //Controlls for mobile.
//        if (Input.touchCount == 1)
//        {
//
//            Touch touch = Input.GetTouch(0);
//
//            if (touch.position.x > Screen.width / 2)
//            {
//                xPos = transform.position.x + paddleSpeed;
//            }
//            else
//            {
//                xPos = transform.position.x - paddleSpeed;
//            }
//        }

        if (Input.touchCount > 0)
        {
            xPos = transform.position.x + (Input.touches[0].deltaPosition.x * touchPaddleSpeed);
        }

        //Clamp is basically limiting the position between 2 floats. So in our case...
        //Our XPosition (Left right) can only be between -8 and 8 -On the X Axis.
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0);

        //Update the position to be the player's position
        transform.position = playerPos;
    }

    public void AdjustTouchPaddleSpeed(float newSpeed)
    {
        touchPaddleSpeed = newSpeed;
        paddleSpeed = newSpeed;
    }


}
