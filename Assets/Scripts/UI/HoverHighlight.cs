using System.Linq;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Highlights a sprite on mouse over. Find or adds a LineRenderer and PolygonCollider2D for use on the GameObject.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class HoverHighlight : MonoBehaviour
    {
        public Color Color = Color.yellow;
        public float Width = 0.05f;

        private LineRenderer _line;
        private PolygonCollider2D _collider;

        void Awake()
        {
            if (!TryGetComponent(out _line)) _line = gameObject.AddComponent<LineRenderer>();
            if (!TryGetComponent(out _collider)) _collider = gameObject.AddComponent<PolygonCollider2D>();
        }

        void Start()
        {
            // Line renderer overrides
            _line.material = GameManager.Instance.Assets.DefaultLine;
            _line.loop = true;
            _line.startColor = _line.endColor = Color;
            _line.startWidth = _line.endWidth = Width;

            // Grab points from polygon collider and feed to line renderer
            var points = _collider.GetPath(0).Select(_localToWorld).ToArray();
            _line.positionCount = points.Length;
            _line.SetPositions(points);
            _line.enabled = false;
        }

        private void OnMouseOver() => _line.enabled = true;
        private void OnMouseExit() => _line.enabled = false;
        private Vector3 _localToWorld(Vector2 v2) => (Vector3) (v2 * transform.lossyScale) + transform.position;
    }
}
