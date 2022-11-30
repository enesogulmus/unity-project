using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float playerSpeed;
    float xPosition;

    public int horizontalSpeed;
    public int speed;

    // Update is called once per frame
    void Update()
    {      
        xPosition = Mathf.Clamp(transform.position.x, -11.694f, -7.75f);
        transform.position = new Vector3(xPosition,transform.position.y,transform.position.z);
    }
}
