using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    //[SerializeField] Waypoint startWaypoint, endWaypoint;
    /*[SerializeField] Waypoint spawnPos1;
    [SerializeField] Waypoint spawnPos2;
    [SerializeField] Waypoint spawnPos3;
    */
    [SerializeField] Waypoint endWaypoint;
    public Waypoint[] startWaypoint;
    public int spawnPointNumber;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;  //dabartinis searchCenter
    List<Waypoint> path = new List<Waypoint>();
    EnemySpawner spawnWave = new EnemySpawner();
    private void Update()
    {
        spawnPointNumber = Random.Range(0, 3);
        //returnStartPoint();
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        //ColorStartandEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    public void CreatePath()
    {
        path.Add(endWaypoint);
        endWaypoint.isPlaceble = false;
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint[returnStartPoint()])
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }

        SetAsPath(startWaypoint[returnStartPoint()]);
        path.Reverse();

    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceble = false;
    }

    public void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint[returnStartPoint()]);   //ideda pirma raide
        while (queue.Count > 0 && isRunning)         //kol kazkas yra eileje
        {
            searchCenter = queue.Dequeue(); //pradinis taskas, kuri isima, ne eina i ji lieciancius
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }

        print("Finished pathfinding?");
    }

    public void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            print("Start and end points are the same");
            isRunning = false;
        }
    }

    public void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction; //susideda kaip vektoriai, nes Vector2Int, o ne kaip stringas
            //print("Exploring " + neighbourCoordinates);

            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //pakartotinai neexplorint
        }

        else
        {
            //neighbour.SetTopColor(Color.yellow);
            queue.Enqueue(neighbour);
            //print("Queueing " + neighbour.name);
            neighbour.exploredFrom = searchCenter;
        }
    }

    /*public void ColorStartandEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }*/

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>(); 
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.LogWarning("Cube is overlapping " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    /*public Waypoint randomSpawnPoint()
     {
         if (true)
         {
             int spawnPointNumber = Random.Range(1, 4);

             if (spawnPointNumber == 1)
             {
                 updatedStartWaypoint = spawnPos1;
             }

             else if (spawnPointNumber == 2)
             {
                 updatedStartWaypoint = spawnPos2;
             }

             else if (spawnPointNumber == 3)
             {
                 updatedStartWaypoint = spawnPos3;
             }
         }

         return updatedStartWaypoint;
     }*/

    public int returnStartPoint()
    {
        return spawnPointNumber;
    }

    public Waypoint[] returnStartWaypoint()
    {
        return startWaypoint;
    }
}
