using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProje1.Controllers
{
    public class LineRendererController : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private Transform[] _points;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void SetUpLine(Transform[] points)
        {
            _lineRenderer.positionCount = points.Length;
            this._points = points;
        }
        private void Update()
        {
            for(int i = 0; i< _points.Length; i++)
            {
                _lineRenderer.SetPosition(i, _points[i].position);
            }
        }
    }

}

