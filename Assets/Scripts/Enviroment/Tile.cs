using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] bool isRoad;
    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();

        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable && !isRoad)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }


    [SerializeField] Tower towerPrefab;
    void OnMouseDown()
    {
        //if (isPlaceable)
        if (gridManager.Grid[coordinates].isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            if (towerPrefab.CreateTower(towerPrefab, transform.position))
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
        }
    }
}
