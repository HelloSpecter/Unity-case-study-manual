using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchTheAim : MonoBehaviour {
    [SerializeField] GameObject[] Aim = new GameObject[3];
    NavMeshAgent m_Agent;
    int i = 0;
    GameObject curAim;
    NavMeshPath curPath;
    Vector3[] pathPoints;
    Vector3 curPoint;
    Vector3 start;
    // Use this for initialization
    void Start () {
        m_Agent = GetComponent<NavMeshAgent>();
        curPoint = transform.position;
        m_Agent.SetDestination(Aim[i].transform.position);
        start = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = transform.position-0.5f*transform.forward.normalized+ 0.2f * Vector3.up.normalized;
        Camera.main.transform.LookAt(transform);
        curPath = m_Agent.path;
        pathPoints = curPath.corners;
        Debug.DrawLine(transform.position, pathPoints[0],Color.red);
        for (int i = 0; i < pathPoints.Length-1; i++)
        {
            Debug.DrawLine(pathPoints[i], pathPoints[i+1], Color.red);
        }

        if (m_Agent.remainingDistance<0.1f||m_Agent.destination==null)
        {
            
            if (i<Aim.Length)
            {
                curAim = Aim[i++];
                m_Agent.SetDestination(curAim.transform.position);
            }
            else
            {
            i = 0;
            m_Agent.SetDestination(start);

            }
            

            
            
            

            //curPoint = transform.position;
        }




    }
}
