using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
public class EnemyPathing : MonoBehaviour
{
    //Reference to the entity that has a path
    public NavMeshAgent m_entityAgent;
    //The waypoints are in order of travelling
    public Transform m_waypointsContainer;
    //Contains all the waypoints
    [SerializeField]
    List<Transform> m_waypoints;
    //The number of waypoints in the list
    [SerializeField]
    int m_waypointsNb;
    //Index of the current destination target of the entity
    [SerializeField]
    int m_destinationIndex;
    //Tell if the entity should wait on each waypoint
    public bool m_sleepOnWayPoint;
    //Waiting time amount
    public float m_waitingTime;
    //Distance threshold before changing path destination
    readonly float m_distanceThreshold = 0.75f;
    //Tells if the entity should go back or loop
    public bool m_backAndForth;
    //Tells if the entity is going backward
    [SerializeField]
    bool m_isGoingBack;
    [SerializeField]
    bool m_handlingWaypoint;

    void Start()
    {
        if (!m_entityAgent)
            m_entityAgent = transform.GetComponentInChildren<NavMeshAgent>();
        if (!m_entityAgent)
        {
            enabled = false;
            return;
        }

        m_waypoints = new List<Transform>();
        if (!m_waypointsContainer)
            m_waypointsContainer = GameObject.FindWithTag("EntityPathWaypoint").transform.parent;
        m_waypointsNb = m_waypointsContainer.childCount;
        for (var i = 0; i < m_waypointsNb; ++i)
            m_waypoints.Add(m_waypointsContainer.GetChild(i));
        if (m_waypoints.Count == 0)
            enabled = false;
        m_entityAgent.SetDestination(m_waypoints[0].transform.position);
        
        StartCoroutine(HandleArrivedAtWaypoint());
    }
    IEnumerator HandleArrivedAtWaypoint()
    {
        while (true)
        {
            if (!m_handlingWaypoint)
                continue;
            
            if (m_sleepOnWayPoint)
            {
                Debug.Log("Waiting at waypoint for " + m_waitingTime + " seconds.");
                yield return new WaitForSeconds(m_waitingTime);
            }
            m_handlingWaypoint = false;
        }
    }

    void Update()
    {
        if (m_handlingWaypoint)
            return;
        
        var distance = Vector3.Distance(m_entityAgent.transform.position, m_waypoints[m_destinationIndex].position);
        if (distance > m_distanceThreshold)
            return;

        Debug.Log("Distance to waypoint " + m_destinationIndex + " : " + distance);
        // Arrived at a waypoint
        m_handlingWaypoint = true;
        // Move to the next waypoint
        if (!m_backAndForth)
            m_destinationIndex = (m_destinationIndex + 1) % m_waypointsNb;
        else
        {
            if (m_destinationIndex == 0 || m_destinationIndex == m_waypointsNb - 1)
                m_isGoingBack ^= true;

            m_destinationIndex = m_isGoingBack ? --m_destinationIndex : ++m_destinationIndex;
        }

        Debug.Log("New destination index = " + m_destinationIndex);
        m_entityAgent.SetDestination(m_waypoints[m_destinationIndex].position);
    }
}
