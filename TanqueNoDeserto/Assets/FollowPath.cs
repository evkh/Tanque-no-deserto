using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    /*/Var que seja o Objetivo
    Transform goal;

    //Não utilizado pra nada
    float speed = 5.0f;

    //Para fazer o calculo da distancia 
    float accuracy = 1.0f;

    //Velocidade da rotação
    float rotSpeed = 2.0f;
    /*/

    //Var para guardar o GameObject com o script WPManager
    public GameObject wpManager;

    //Array com os waypoints
    GameObject[] wps;

    //Instancia o NavmeshAgent
    UnityEngine.AI.NavMeshAgent agent;

    /*/Marca o Nó atual
    GameObject currentNode;


    //Setando o Wp atual pra 0
    int currentWP = 0;

    //Variavel para o Graph
    Graph g;
    /*/

    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        wps = wpManager.GetComponent<WPManager>().waypoints;

        /*/ Pegando as variaveis existentes no script WPManager
        g = wpManager.GetComponent<WPManager>().graph;

        //Setando o Nó pra wps 0
        currentNode = wps[0];
        /*/
    }

    // Método linkado ao button para fazer o tank ir ate o Heliporto
    public void GoToHeli()
    {
        agent.SetDestination(wps[9].transform.position);

        /*/
        Faz o Caminho do nó atual até o locar objetivo
        g.AStar(currentNode, wps[9]);
        //Setando o Wp atual pra 0
        currentWP = 0;
        /*/
    }

    // Método linkado ao button para fazer o tank ir ate as ruinas 
    public void GoToRuin()
    {
        agent.SetDestination(wps[2].transform.position);
        /*/
        Faz o Caminho do nó atual até o locar objetivo
        g.AStar(currentNode, wps[2]);
        //Setando o Wp atual pra 0
        currentWP = 0;
        /*/
    }

    // Método linkado ao button para fazer o tank ir ate a fabrica 
    public void GoToFab()
    {
        agent.SetDestination(wps[6].transform.position);
        /*/
        Faz o Caminho do nó atual até o locar objetivo
        g.AStar(currentNode, wps[6]);
        //Setando o Wp atual pra 0
        currentWP = 0;
        /*/
    }

    /*/
         void LateUpdate()
     {
         //Utilizando o graph
         if (g.getPathLength() == 0 || currentWP == g.getPathLength())
           return;

         //Ve o nó mais proximo
         currentNode = g.getPathPoint(currentWP);

         //Calcula a distancia de dois vetores e se menor que a accuracy, soma 1 ao current waypoint
         if (Vector3.Distance(g.getPathPoint(currentWP).transform.position,transform.position) < accuracy)
         {
             currentWP++;
         }

         //verifica se o Wp atual é menor que o g.getPathLength
         if (currentWP < g.getPathLength())
         {
             //define o objetivo
             goal = g.getPathPoint(currentWP).transform;

             //Vira ele pro objetivo
             Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y,goal.position.z);

             //Se dirige ate o objetivo
             Vector3 direction = lookAtGoal - this.transform.position; this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime * rotSpeed);
         }

         //Faz o player se mover / Professor não colocou no slide

         this.transform.Translate(0, 0, speed * Time.deltaTime);
     }
     /*/
}
