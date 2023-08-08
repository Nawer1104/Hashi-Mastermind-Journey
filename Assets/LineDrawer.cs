using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class LineDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Point startPoint;
    public Point lastPoint;

    private Vector2 mousePos;
    private Vector2 startMousePos;

    private bool canDrawLine = false;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(startMousePos, Vector2.zero);

            if (hit.collider != null)
            {
                canDrawLine = true;
                startPoint = hit.collider.gameObject.GetComponent<Point>();
                //points.Add(hit.collider.gameObject.GetComponent<Point>());
            }
        }

        else if (Input.GetMouseButton(0))
        {
            if (!canDrawLine) return;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
            lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
        }

        else if (Input.GetMouseButtonUp(0))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null)
            {
                lastPoint = hit.collider.gameObject.GetComponent<Point>();
                if (startPoint.GetNumber() == lastPoint.GetNumber())
                {
                    lineRenderer.SetPosition(0, Vector3.zero);
                    lineRenderer.SetPosition(1, Vector3.zero);

                    startPoint.ChangeColor();
                    lastPoint.ChangeColor();
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].points.Remove(startPoint);
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].points.Remove(lastPoint);
                }
            } 
            else
            {
                canDrawLine = false;
            }
        }
    }

}
