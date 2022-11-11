using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    // defines private variable left and right position 
    private float transformOfAxisOfX;
    // defines public get method of horizontal value
    public float TransformOfAxisOfX
    {
        get { return transformOfAxisOfX; }
    }
    void Update()
    {
        HandleHeroHorizontalInput();
    }

    // initial horizontal value when mouse move X axis 
    private void HandleHeroHorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            transformOfAxisOfX = Input.GetAxis("Mouse X");
        }
        else
        {
            transformOfAxisOfX = 0;
        }
    }
}
