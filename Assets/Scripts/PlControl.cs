using System.Collections;                 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class PlControl : MonoBehaviour
{
    public UI _uiComponent;
    public Queue<Vector3> ChestPositionPoint = new();
    private LineRenderer _lineRenderer;
    private float _speed=9;
    private bool _isMoving = false;
    private void Start()
    {
        _uiComponent = GetComponent<UI>();
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.endWidth = 0.5f;
        _lineRenderer.startWidth = 0.5f;
        _lineRenderer.sortingOrder = 0;
    }
    void Update()
    {
        _speed = _uiComponent.Speed;
        UpdateLineRenderer(ChestPositionPoint);
        if (Input.GetMouseButtonDown(1))
        {
            PointCreator();
        }
        if (_isMoving)
        {
            bool ArePositionsClose(Vector2 pos1, Vector2 pos2, float tolerance = 0.01f)
            {
                return Vector2.Distance(pos1, pos2) < tolerance;
            }
            if (ArePositionsClose(transform.position, ChestPositionPoint.Peek()))
            {
                ChestPositionPoint.Dequeue();
                _isMoving = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, ChestPositionPoint.Peek(), _speed * Time.deltaTime);
            }
        }
        else
        {
            if (ChestPositionPoint.Count > 0)
            {
                _isMoving = true;
            }
        }
    }
    public void PointCreator()
    {
        Vector3 PositionPoint = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ChestPositionPoint.Enqueue(PositionPoint);
    }
    public void UpdateLineRenderer(Queue<Vector3> queue)
    {
        _lineRenderer.positionCount = queue.Count;
        _lineRenderer.SetPositions(queue.ToArray());
    }
}
