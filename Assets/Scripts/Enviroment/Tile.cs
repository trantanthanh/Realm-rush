using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] bool isRoad;
    GridManager gridManager;
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

        if (gridManager != null )
        {
            if (!isPlaceable && !isRoad)
            {
                gridManager.BlockNode(transform.position);
            }
        }
    }


    [SerializeField] Tower towerPrefab;
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            if (towerPrefab.CreateTower(towerPrefab, transform.position))
            {
                isPlaceable = false;
            }
        }
    }
}
