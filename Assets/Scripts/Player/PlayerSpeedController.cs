using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    // access of PlayerInputController
    [SerializeField] private PlayerInputController playerInputController;

    //defines variable player speed on z axis
    [SerializeField] private float axisOfZSpeedOfPlayer;
    //defines variable player speed on x axis
    [SerializeField] private float axisOfXSpeedOfPlayer;
    //defines variable player can move limit on x axis
    [SerializeField] private float axisOfXOfLimit;
    //defines variable position of x axis when player movement
    private float positionOfPlayerOnAxisOfX;
    

    // Update is called once per frame for player always moves
    void FixedUpdate()
    {
        SetAxisOfZOfPlayerMovement();
        SetAxisOfXOfPlayerMovement();
    }
    // set player movement
    // we should use fixedDeltaTime because we use fixedUpdate method
    private void SetAxisOfZOfPlayerMovement()
    {
        transform.Translate(Vector3.forward * axisOfZSpeedOfPlayer * Time.fixedDeltaTime);
    }private void SetAxisOfXOfPlayerMovement()
    {
        positionOfPlayerOnAxisOfX = transform.position.x + playerInputController.TransformOfAxisOfX * axisOfXSpeedOfPlayer * Time.fixedDeltaTime;
        positionOfPlayerOnAxisOfX = Mathf.Clamp(positionOfPlayerOnAxisOfX, -axisOfXOfLimit, axisOfXOfLimit);
        transform.position = new Vector3(positionOfPlayerOnAxisOfX, transform.position.y, transform.position.z);
    }
}
