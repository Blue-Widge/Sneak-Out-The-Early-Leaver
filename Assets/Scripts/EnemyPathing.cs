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
    //Animator of the entity walking if existing
    public Animator m_entityAnimator;
    //Contains all the waypoints
    [SerializeField]
    private List<Transform> m_waypoints;
    //The number of waypoints in the list
    [SerializeField]
    private int m_waypointsNb;
    //Index of the current destination target of the entity
    [SerializeField]
    private int m_destinationIndex;
    //Tell if the entity should wait on each waypoint
    public bool m_sleepOnWayPoint;
    //Waiting time amount
    public float m_waitingTime;
    //Distance threshold before changing path destination
    private readonly float m_distanceThreshold = 1f;
    //Tells if the entity should go back or loop
    public bool m_backAndForth;
    //Tells if the entity is going backward
    [SerializeField]
    private bool m_isGoingBack;
    [SerializeField]
    private bool m_isWaiting;
    void Start()
    {
        if (!m_entityAgent)
            m_entityAgent = this.transform.GetComponentInChildren<NavMeshAgent>();
        if (!m_entityAgent)
        {
            this.enabled = false;
            return;
        }

        if (!m_entityAnimator)
            m_entityAnimator = GetComponentInChildren<Animator>();
        m_waypoints = new List<Transform>();
        if (!m_waypointsContainer)
            m_waypointsContainer = GameObject.FindWithTag($"EntityPathWaypoint").transform.parent;
        m_waypointsNb = m_waypointsContainer.childCount;
        for (int i = 0; i < m_waypointsNb; ++i)
            m_waypoints.Add(m_waypointsContainer.GetChild(i));
        if (m_waypoints.Count == 0)
            this.enabled = false;
        m_entityAgent.SetDestination(m_waypoints[0].transform.position);
        m_destinationIndex = 0;
        StartCoroutine(HandleWaypointReached());
    }
    void Update()
    {
        if (m_entityAnimator)
            m_entityAnimator.SetFloat("WalkingSpeed", m_entityAgent.velocity.magnitude);

        var distance = Vector3.Distance(m_entityAgent.transform.position, m_waypoints[m_destinationIndex].position);
        if (distance > m_distanceThreshold)
            return;

        m_isWaiting = true;
        if (m_entityAnimator)
            m_entityAnimator.SetBool("Walking", false);
    }

    IEnumerator HandleWaypointReached()
    {
        while (enabled && Application.isPlaying)
        {
            if (m_isWaiting)
            {
                if (m_sleepOnWayPoint)
                    yield return new WaitForSeconds(m_waitingTime);

                if (!m_backAndForth)
                {
                    m_destinationIndex = (m_destinationIndex + 1) % m_waypointsNb;
                    m_entityAgent.SetDestination(m_waypoints[m_destinationIndex].transform.position);
                    Debug.Log("Arrived at waypoint, going to index " + m_destinationIndex);
                }
                else
                {
                    if ((m_destinationIndex == 0 && m_isGoingBack) || (m_destinationIndex == m_waypointsNb - 1 && !m_isGoingBack))
                        m_isGoingBack ^= true;

                    m_destinationIndex = m_isGoingBack ? --m_destinationIndex : ++m_destinationIndex;
                    Debug.Log("New destination index = " + m_destinationIndex);
                    m_entityAgent.SetDestination(m_waypoints[m_destinationIndex].transform.position);
                }
                m_isWaiting = false;
                if (m_entityAnimator)
                    m_entityAnimator.SetBool("Walking", true);
            }

            yield return null;
        }
    }

}
