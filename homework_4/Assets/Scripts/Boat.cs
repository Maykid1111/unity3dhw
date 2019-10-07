using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat{
    public int Count;                       
    public int pos;  
    public int[] State;                                          
    public GameObject thisboat;
    public Boat()
    {
        Count = 0;
        pos = 0;
        State = new int[2];
        State[0] = State[1] = 0;
        thisboat = Object.Instantiate(Resources.Load("Boat", typeof(GameObject)), new Vector3(0, -4, 5), Quaternion.identity) as GameObject;
        thisboat.name = "boat";
    }
}
