using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class NewNPC : MonoBehaviour
{
    // Start is called before the first frame update

    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;
    float viewAngle;
    Color orginal;

    public bool caught;

    Transform player;
    public GameObject c;
    NavMeshAgent agent;
 
    NewWayPoint wayPointScript;

    //Path1
    [SerializeField]
    Transform startingPoint1;
    [SerializeField]
    Transform previousPoint1;
    [SerializeField]
    Transform currentPoint1;
    [SerializeField]
    int numberOfMoves1 = 0;
    int destPoint = 0;

    //Path 2
    [SerializeField]
    Transform startingPoint2;
    [SerializeField]
    Transform previousPoint2;
    [SerializeField]
    Transform currentPoint2;
    [SerializeField]
    int numberOfMoves2 = 0;
    int destPoint2 = 0;

    //Path3
    [SerializeField]
    Transform startingPoint3;
    [SerializeField]
    Transform previousPoint3;
    [SerializeField]
    Transform currentPoint3;
    [SerializeField]
    int numberOfMoves3 = 0;
    int destPoint3 = 0;

    //Path4
    [SerializeField]
    Transform startingPoint4;
    [SerializeField]
    Transform previousPoint4;
    [SerializeField]
    Transform currentPoint4;
    [SerializeField]
    int numberOfMoves4 = 0;
    int destPoint4 = 0;

    //Path5
    [SerializeField]
    Transform startingPoint5;
    [SerializeField]
    Transform previousPoint5;
    [SerializeField]
    Transform currentPoint5;
    [SerializeField]
    int numberOfMoves5 = 0;
    int destPoint5 = 0;


    //Path6
    [SerializeField]
    Transform startingPoint6;
    [SerializeField]
    Transform previousPoint6;
    [SerializeField]
    Transform currentPoint6;
    [SerializeField]
    int numberOfMoves6 = 0;
    int destPoint6 = 0;

    void Start()
    {
        orginal = spotlight.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        wayPointScript = GameObject.Find("PatrolPoints").GetComponent<NewWayPoint>();
        
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.01f)
        {
       
            GotoNextPoint();
            
        }

        StartCoroutine("Caught");
    }

    IEnumerator Caught()
    {
        if (CanSeePlayer())
        {
            caught = true;
            spotlight.color = Color.red;
            c.SetActive(true);
            yield return new WaitForSeconds(.5f);
            if (caught == true && CanSeePlayer())
            {
                Destroy(player.gameObject);
                SceneManager.LoadScene("DeadScreen");
            }
           

        }
        else
        {
            c.SetActive(false);
            caught = false;
            spotlight.color = orginal;

        }
        yield return null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
   
    bool CanSeePlayer()
    {
       
        if(Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle /2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                   
                }
            }
        }
        return false;
    }

    void GotoNextPoint()
    {
        if (wayPointScript.Path1.Count == 0)
            return;

        NavigationHandler();
        
   
        
    }

    void OnCollisionEnter(Collision NPC) {
        if (NPC.transform.GetComponents<NavMeshAgent>() != null)
        {
            NavigationHandler();
        }
    }


    void NavigationHandler()
    {
        if (transform.tag == ("o"))
        {

            destPoint = Random.Range(0, wayPointScript.Path1.Count);

            if (numberOfMoves1 == 0)
            {
                startingPoint1 = wayPointScript.Path1[destPoint].transform;
                agent.SetDestination(startingPoint1.position);
                numberOfMoves1++;
                previousPoint1 = startingPoint1;
            }
            else if (numberOfMoves1 > 0)
            {

                previousPoint1 = currentPoint1;

                currentPoint1 = wayPointScript.Path1[destPoint].transform;

                if (currentPoint1 == ((currentPoint3) || (currentPoint2)))
                {
                    destPoint = Random.Range(0, wayPointScript.Path1.Count);
                    currentPoint1 = wayPointScript.Path1[destPoint].transform;
                } else
                {
                    currentPoint1 = wayPointScript.Path1[destPoint].transform;
                }
                

                    agent.SetDestination(currentPoint1.position);
                    numberOfMoves1++;
                
               
               
            }

        }

        else if (transform.tag == ("t"))
        {

            destPoint2 = Random.Range(0, wayPointScript.Path2.Count);

            if (numberOfMoves2 == 0)
            {
                startingPoint2 = wayPointScript.Path2[destPoint2].transform;
                agent.SetDestination(startingPoint2.position);
                numberOfMoves2++;
                previousPoint2 = startingPoint2;
            }
            else if (numberOfMoves2 > 0)
            {

                previousPoint2 = currentPoint2;

                currentPoint2 = wayPointScript.Path2[destPoint2].transform;

                if (currentPoint2 == ((currentPoint1) || (currentPoint3)))
                {
                    destPoint2 = Random.Range(0, wayPointScript.Path2.Count);
                    currentPoint2 = wayPointScript.Path2[destPoint2].transform;
                }
                else
                {
                    currentPoint2 = wayPointScript.Path2[destPoint2].transform;
                }


                agent.SetDestination(currentPoint2.position);
                numberOfMoves2++;
            }

        }



        else if (transform.tag == ("ot"))
        {

            destPoint3 = Random.Range(0, wayPointScript.Path3.Count);

            if (numberOfMoves3 == 0)
            {
                startingPoint3 = wayPointScript.Path3[destPoint3].transform;
                agent.SetDestination(startingPoint3.position);
                numberOfMoves3++;
                previousPoint3 = startingPoint3;
            }
            else if (numberOfMoves3 > 0)
            {

                previousPoint3 = currentPoint3;

                currentPoint3 = wayPointScript.Path3[destPoint3].transform;

                if (currentPoint3 == ((currentPoint1) || (currentPoint2)) )
                {
                    destPoint3 = Random.Range(0, wayPointScript.Path3.Count);
                    currentPoint3 = wayPointScript.Path3[destPoint3].transform;
                }
                else
                {
                    currentPoint3 = wayPointScript.Path3[destPoint3].transform;
                }


                agent.SetDestination(currentPoint3.position);
                numberOfMoves3++;
            }

        }


        else if (transform.tag == ("hre"))
        {

            destPoint4 = Random.Range(0, wayPointScript.Path4.Count);

            if (numberOfMoves4 == 0)
            {
                startingPoint4 = wayPointScript.Path4[destPoint4].transform;
                agent.SetDestination(startingPoint4.position);
                numberOfMoves4++;
                previousPoint4 = startingPoint4;
            }
            else if (numberOfMoves4 > 0)
            {

                previousPoint4 = currentPoint4;

                currentPoint4 = wayPointScript.Path4[destPoint4].transform;

                if (currentPoint4 == ((currentPoint1) || (currentPoint2)))
                {
                    destPoint4 = Random.Range(0, wayPointScript.Path4.Count);
                    currentPoint4 = wayPointScript.Path4[destPoint4].transform;
                }
                else
                {
                    currentPoint4 = wayPointScript.Path4[destPoint4].transform;
                }


                agent.SetDestination(currentPoint4.position);
                numberOfMoves4++;
            }

        }


        else if (transform.tag == ("f"))
        {

            destPoint5 = Random.Range(0, wayPointScript.Path5.Count);

            if (numberOfMoves5 == 0)
            {
                startingPoint5 = wayPointScript.Path5[destPoint5].transform;
                agent.SetDestination(startingPoint5.position);
                numberOfMoves5++;
                previousPoint5 = startingPoint5;
            }
            else if (numberOfMoves5 > 0)
            {

                previousPoint5 = currentPoint5;

                currentPoint5 = wayPointScript.Path5[destPoint5].transform;

                if (currentPoint5 == ((currentPoint1) || (currentPoint2)))
                {
                    destPoint5 = Random.Range(0, wayPointScript.Path5.Count);
                    currentPoint5 = wayPointScript.Path5[destPoint5].transform;
                }
                else
                {
                    currentPoint5 = wayPointScript.Path5[destPoint5].transform;
                }


                agent.SetDestination(currentPoint5.position);
                numberOfMoves5++;
            }

        }


        else if (transform.tag == ("s"))
        {

            destPoint6 = Random.Range(0, wayPointScript.Path6.Count);

            if (numberOfMoves6 == 0)
            {
                startingPoint6 = wayPointScript.Path6[destPoint6].transform;
                agent.SetDestination(startingPoint6.position);
                numberOfMoves6++;
                previousPoint6 = startingPoint6;
            }
            else if (numberOfMoves6 > 0)
            {

                previousPoint6 = currentPoint6;

                currentPoint6 = wayPointScript.Path6[destPoint6].transform;

                if (currentPoint6 == ((currentPoint1) || (currentPoint2)))
                {
                    destPoint6 = Random.Range(0, wayPointScript.Path6.Count);
                    currentPoint6 = wayPointScript.Path6[destPoint6].transform;
                }
                else
                {
                    currentPoint6 = wayPointScript.Path6[destPoint6].transform;
                }


                agent.SetDestination(currentPoint6.position);
                numberOfMoves6++;
            }

        }


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
