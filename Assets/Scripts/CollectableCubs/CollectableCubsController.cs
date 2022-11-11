using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCubsController : MonoBehaviour
{

    [SerializeField] private PlayerCollectController playerCollectController;
    private bool isAddToList = false;
    private RaycastHit rays;
    private Vector3 directionOfRays = Vector3.back;
    // Start is called before the first frame update
    void Start()
    {
        playerCollectController = GameObject.FindObjectOfType<PlayerCollectController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RunCollectRays();
    }

    private void RunCollectRays()
    {
        if (Physics.Raycast(transform.position, directionOfRays, out rays, 0.04f))
        {
            if(!isAddToList)
            {
                isAddToList = true;
                playerCollectController.addCollectableCubs(gameObject);
                RunDistributeRays();
            }
            // if mainCube meet above names of object, run remove method
            if (rays.transform.name == "obstacleRedCub" || rays.transform.name == "obstaclePinkCub" || rays.transform.name == "obstacleYellowCub" || rays.transform.name == "obstacleBlueCub")
            {
                playerCollectController.removeCollectableCubs(gameObject);
                RunFinishRays();
            }
            if(rays.transform.name == "finishPointBlack" || rays.transform.name == "finishPointBlack")
            {
                //playerCollectController.finishPoint(gameObject);
            }
        }
        
    }
    //obstacle rays method
    private void RunDistributeRays()
    {
        directionOfRays = Vector3.forward;
    }private void RunFinishRays()
    {
        directionOfRays = Vector3.up;
    }
}
