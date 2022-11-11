using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    //defines gameObject List for collected cubs
    public List<GameObject> collectableCubs = new List<GameObject>();
    private GameObject lastCollectableCub;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLastCollectableCub();
    }
    //defines method for changing position of player and collected cubs when collect cub
    public void addCollectableCubs(GameObject _gameObject)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.043f, transform.position.z);
        //last collectable cub positon
        _gameObject.transform.position = new Vector3(lastCollectableCub.transform.position.x, lastCollectableCub.transform.position.y - 0.043f, lastCollectableCub.transform.position.z);
        //collected cub set to be child of mainCub object
        _gameObject.transform.SetParent(transform);

        collectableCubs.Add(_gameObject);
        UpdateLastCollectableCub();
    }
    //remove cube at list method
    public void removeCollectableCubs(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        collectableCubs.Remove(_gameObject);
        UpdateLastCollectableCub();
    }

    public void UpdateLastCollectableCub()
    {
        lastCollectableCub = collectableCubs[collectableCubs.Count - 1];
    }
}
