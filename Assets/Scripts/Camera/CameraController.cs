using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //define variable player transform for camera
    [SerializeField] private Transform transformOfPlayer;
    private Vector3 offset;
    private Vector3 currentPositionOfCamera;
    [SerializeField] private float lerpValue;

    // Start is called before the first frame update
    void Start()
    {
        //camera transform minus player current transform
        offset = transform.position - transformOfPlayer.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        currentPositionOfCamera = Vector3.Lerp(transform.position, new Vector3(0f, transformOfPlayer.position.y, transformOfPlayer.position.z) + offset, lerpValue*Time.deltaTime);
        transform.position = currentPositionOfCamera;
    }
}
