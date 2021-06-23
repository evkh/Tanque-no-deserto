using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//Opções do Inspector do Link
public struct Link
{
    public enum direction { UNI, BI }
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WPManager : MonoBehaviour
{
    //Array para colocar os Waypoints
    public GameObject[] waypoints;

    //Array para linkar os Waypoints
    public Link[] links;

    //Var para utilizar o Graph
    public Graph graph = new Graph();


    void Start()
    {
        //Verifica se o Array tem algo dentro
        if (waypoints.Length > 0)
        {
            //Para cada GameObject no Array
            foreach (GameObject wp in waypoints)
            {
                //Adiciona um nó
                graph.AddNode(wp);
            }

            //Para cada GameObject no Array Links
            foreach (Link l in links)
            {
                //Usa o graph para adicionar uma Edge
                graph.AddEdge(l.node1, l.node2);

                //Verefica se a dir esta setada como BI
                if (l.dir == Link.direction.BI)
                    //Adiciona uma Edge
                    graph.AddEdge(l.node2, l.node1);
            }
        }
    }

    void Update()
    {
        //Debug
        graph.debugDraw();
    }
}

