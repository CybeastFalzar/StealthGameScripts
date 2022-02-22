using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NewWayPoint : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]
     public  List<GameObject> Path1;

   [SerializeField]
    public  List<GameObject> Path2;

    [SerializeField]
    public List<GameObject> Path3;

    [SerializeField]
    public List<GameObject> Path4;

    [SerializeField]
    public List<GameObject> Path5;

    [SerializeField]
    public List<GameObject> Path6;

    List<GameObject> allPoints;

    //Path1

 


    void Start()
    {
        
        allPoints = new List<GameObject>();
        
        Path1 = new List<GameObject>();
        Path2 = new List<GameObject>();
        Path4 = new List<GameObject>();

        foreach (Transform child in transform)
        {
            allPoints.Add(child.gameObject);
        }

        for (int i = 0; i < allPoints.Count; i++)
        {
            if (allPoints[i].tag.Contains ("o"))
            {
                Path1.Add(allPoints[i]);
            }
        }

        for (int i = 0; i < allPoints.Count; i++)
        {
            if (allPoints[i].tag.Contains ("t"))
            {
                Path2.Add(allPoints[i]);
            }
        }

        for (int i = 0; i < allPoints.Count; i++)
        {
            if (allPoints[i].tag == ("hre"))
            {
                Path4.Add(allPoints[i]);
            }
        }

        for (int i = 0; i < allPoints.Count; i++)
        {
            if (allPoints[i].tag == ("f"))
            {
                Path5.Add(allPoints[i]);
            }
        }

        for (int i = 0; i < allPoints.Count; i++)
        {
            if (allPoints[i].tag == ("s"))
            {
                Path6.Add(allPoints[i]);
            }
        }

        Path3.AddRange(Path1);
        Path3.AddRange(Path2);


    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

  
}


/// <summary> 
/// 1. Establish # of unique paths
/// 2. Find all waypoints in scene
/// 3. Find all waypoints for each specific path and put them in an array 
/// 4. Go randomly between specific points in each path for every patroller in the path 
///     - Keep track of current point and the next point 
///     - Distance from next point
///     
/// 
/// </summary> 