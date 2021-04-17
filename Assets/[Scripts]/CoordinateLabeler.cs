using TMPro;
using UnityEngine;

namespace Editor
{
    [ExecuteAlways]
    public class CoordinateLabeler : MonoBehaviour
    {
        private Vector2Int _coordinates;
        [SerializeField] private TextMeshPro label;

        private void Awake()
        {
            //label = GetComponent<TextMeshPro>();
        }

        private void Update()
        {
            if (!Application.isPlaying)
            {
                SetLabel();
            }

            if (Application.isPlaying)
            {
                label.text = "";
            }
        }

        void SetLabel()
        {
            _coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
            _coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
            label.text = _coordinates.x + "," + _coordinates.y;
            label.transform.parent.name = _coordinates.ToString();
        }
    }
}