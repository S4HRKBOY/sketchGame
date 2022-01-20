using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{       
    public bool notSearchingAnymore;   
    public Transform target;

    public Transform initialSpawnPosition;

    public float speed = 1;
    Vector2[] path;
    int targetIndex;

    private void Awake()
    {
        initialSpawnPosition = calculateInitialSpawnposition();
    }

    private void Start()
    {        
        target = GameObject.FindGameObjectWithTag("Player").transform;        
    }

    public void requestPath()
    {
        PathRequestManager.RequestPath(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x, target.position.y), onPathFound);
    }

    public void returnHome()
    {
        PathRequestManager.RequestPath(new Vector2(transform.position.x, transform.position.y), new Vector2(initialSpawnPosition.position.x,initialSpawnPosition.position.y), onPathFound);
    }
   
    public void onPathFound(Vector2[] newPath, bool pathSucessful)
    {
        notSearchingAnymore = false;
        if (pathSucessful)
        {            
            path = newPath;
            targetIndex = 0;
            StopCoroutine("followPath");          
            StartCoroutine("followPath");
        }        
    }

    IEnumerator followPath()
    {
        if(path.Length == 0)
        {
            yield break;
        }
        Vector2 currentWaypoint = path[0];
        while (true)
        {
            if(new Vector2(transform.position.x, transform.position.y) == currentWaypoint)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];                
            }
                                                  
            if (notSearchingAnymore)
            {
                
                path[path.Length-1] = new Vector2(transform.position.x,transform.position.y);
                currentWaypoint = path[path.Length - 1];                
            }           
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), currentWaypoint, speed * Time.deltaTime);           
            yield return null;
        }

    }

    public void adjustRotation()
    {
        var targetPos = target.position;
        var thisPos = transform.position;

        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;

        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private Transform calculateInitialSpawnposition()
    {
        Collider2D[] lookForPosition = Physics2D.OverlapCircleAll(transform.position, 3f);
        for(int i = 0;i< lookForPosition.Length; i++)
        {
            if (lookForPosition[i].gameObject.layer == 11)
                return lookForPosition[i].GetComponent<Transform>();
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        if(path != null)
        {
            for(int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if(i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, new Vector3(path[i].x, path[i].y, 1));
                }
                else
                {
                    Gizmos.DrawLine(new Vector3(path[i - 1].x, path[i - 1].y, 1), new Vector3(path[i].x, path[i].y, 1));
                }
            }
        }
    }

}
