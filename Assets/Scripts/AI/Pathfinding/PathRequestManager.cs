using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRequestManager : MonoBehaviour
{
    Queue<PathRequest> pathRequestQueue = new Queue<PathRequest>();
    PathRequest currentPathRequest;

    static PathRequestManager instance;
    Pathfinding pathfinding;

    bool isProcessingPath;

    private void Awake()
    {
        pathfinding = GetComponent<Pathfinding>();
        instance = this;
    }

    public static void RequestPath(Vector2 pathStart,Vector2 pathEnd,Action<Vector2[],bool> callback)
    {
        PathRequest newRequest = new PathRequest(pathStart, pathEnd, callback);
        instance.pathRequestQueue.Enqueue(newRequest);
        instance.tryProcessNext();
    }

    void tryProcessNext()
    {
        if(!isProcessingPath && pathRequestQueue.Count > 0)
        {
            currentPathRequest = pathRequestQueue.Dequeue();
            isProcessingPath = true;
            pathfinding.startFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
        }

    }

    public void finishedProcessingPath(Vector2[] path,bool sucess)
    {
        currentPathRequest.callback(path, sucess);
        isProcessingPath = false;
        tryProcessNext();
    }

    struct PathRequest
    {
        public Vector2 pathStart;
        public Vector2 pathEnd;
        public Action<Vector2[], bool> callback;

        public PathRequest(Vector2 _pathstart,Vector2 _pathEnd,Action<Vector2[],bool> _callback)
        {
            pathStart = _pathstart;
            pathEnd = _pathEnd;
            callback = _callback;
        }

    }

}
