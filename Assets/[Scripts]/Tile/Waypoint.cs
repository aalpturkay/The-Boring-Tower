using UnityEngine;

namespace Tile
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private bool isPlaceable;
        [SerializeField] private Tower tower;
        public bool IsPlaceable => isPlaceable;

        private void OnMouseDown()
        {
            if (isPlaceable)
            {
                bool isPlaced = tower.InstantiateTower(tower, transform.position, transform);
                isPlaceable = !isPlaced;
            }
        }
    }
}