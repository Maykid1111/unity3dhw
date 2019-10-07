using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role {
    public int pos;             // 0左 1右 2船上
    public int boatPos;         // 0左 1右
    public Vector3 fromPos;     // 起始点
    public Vector3 toPos;       // 目的点
    public GameObject _object;

    public Role(string name)
    {
        pos = 0;
        _object = Object.Instantiate(Resources.Load(name, typeof(GameObject)), Vector3.zero, Quaternion.identity) as GameObject;
    }

    

    public void getBoat(int i)
    {
        pos = 2;
        if (i == 1)
        {
            boatPos = 0;
            _object.transform.position = new Vector3(0, -3, 4);
        }
        else if(i == 2)
        {
            boatPos = 1;
            _object.transform.position = new Vector3(0, -3, 6);
        }
        else if(i == 3)
        {
            boatPos = 1;
            _object.transform.position = new Vector3(0, -3, -4);
        }
        else
        {
            boatPos = 0;
            _object.transform.position = new Vector3(0, -3, -6);
        }
    }

    public void setName(string name)
    {
        _object.name = name;
    }

    public void setFromPos(Vector3 i)
    {
        _object.transform.position = i;
        fromPos = i;
    }

    public void setToPos(Vector3 i)
    {
        toPos = i;
    }

    public void MoveToFromPos()
    {       
        _object.transform.position = fromPos;
        pos = 0;
    }

    public void MoveToToPos()
    {
        pos = 1;
        _object.transform.position = toPos;
    }

}
