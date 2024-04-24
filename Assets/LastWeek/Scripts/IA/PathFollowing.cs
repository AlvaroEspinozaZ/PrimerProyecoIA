using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypePath { Comer, Jugar, Banno, Dormir }

[System.Serializable]
public class DataPath
{
    public TypePath type;
    public Transform[] paths;
    public DataPath()
    {
    }
}

public class PathFollowing : MonoBehaviour
{
    public TypePath type;
    public List<DataPath> datapaths = new List<DataPath>();

    Dictionary<TypePath, Transform[]> dictPath = new Dictionary<TypePath, Transform[]>();

    [Header("Gizmo")]
    public float gizmoRadius = 1.0f;
    public Color[] gizmoColor = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };
    public Color[] LineColor = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };
    void Awake()
    {
        foreach (var path in datapaths)
        {
            dictPath.Add(path.type, path.paths);
        }

        foreach (var elemt in datapaths)
        {

            foreach (Transform t in elemt.paths)
            {
               // Debug.Log("Key:" + elemt.type + " -> Value: " + t.position);

            }
        }
    }
    public Transform[] GetPaths(TypePath type)
    {      
        return dictPath[type];
    }
    void OnDrawGizmos()
    {
        int colorIndex = 0; 
        foreach (var path in datapaths)
        {
            for(int i = 0; i < path.paths.Length; i++)
            {
                Gizmos.color = LineColor[colorIndex % LineColor.Length];
                Gizmos.DrawWireSphere(path.paths[i].position, gizmoRadius);

                if(i< path.paths.Length-1 )
                {
                    Gizmos.color = LineColor[colorIndex % LineColor.Length];
                    Gizmos.DrawLine(path.paths[i].position,path.paths[i + 1].position);

                }
            }
        colorIndex++;
        }

    }
}