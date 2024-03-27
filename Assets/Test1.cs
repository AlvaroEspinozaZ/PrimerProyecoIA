using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public BehaviursIA _mybe;
    public PathFollowing _mypath;
    public int id = 0;
    public int lostipos = 0;
    private void Awake()
    {
        _mybe = GetComponent<BehaviursIA>();
        _mypath = GetComponent<PathFollowing>();
        _mybe.Point = _mypath.datapaths[lostipos].paths[id];

    }
    private void Update()
    {
        NextPath();
    }
    public void NextPath()
    {
        Debug.Log(_mypath.GetPaths(_mypath.datapaths[lostipos].type).Length);
        if (id < _mypath.GetPaths(_mypath.datapaths[lostipos].type).Length-1)
        {
            float distanceToCurrent = Vector3.Distance(transform.position, _mypath.GetPaths(_mypath.datapaths[lostipos].type)[id].position);
            Debug.Log(distanceToCurrent);
            if (distanceToCurrent < 0.5f)
            {
                id++;
                _mybe.Point = _mypath.GetPaths(_mypath.datapaths[lostipos].type)[id];
            }
        }       
    }
}
