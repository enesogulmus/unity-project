using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public List<GameObject> stackList;
    public int height = 0;
    public GameObject mainCube;
   


    // Start is called before the first frame update
    void Start()
    {

    }
    public void lowHeight()
    {
        height--;

    }

    void Update()
    {
      

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Cube") && other.GetComponent<Cube>().isTouch == false)
        {
            height++;
            mainCube.transform.position = new Vector3(transform.position.x, height, transform.position.z);
            other.gameObject.transform.parent = mainCube.transform;
            other.transform.localPosition= new Vector3(0, -height,0);
            other.GetComponent<Cube>().isTouch = true;
           
        }

        if (other.CompareTag("Cubes"))
        {

            for (int i = 0; i < other.transform.childCount; i++)
            {

                stackList.Add(other.transform.GetChild(i).gameObject);
              

            }

            for (int i = 0; i < stackList.Count; i++)
            {

                height++;
                mainCube.transform.position = new Vector3(transform.position.x, height, transform.position.z);
                stackList[i].gameObject.transform.parent = mainCube.transform;
                stackList[i].transform.localPosition = new Vector3(0, -height, 0);
                stackList[i].GetComponent<Cube>().isTouch = true;


               
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cubes"))
        {
            stackList.Clear();
        }
    }

}
