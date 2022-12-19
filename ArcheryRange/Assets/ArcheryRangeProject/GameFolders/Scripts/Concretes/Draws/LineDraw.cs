using System.Collections;
using System.Collections.Generic;
using UdemyProje1.Combats;
using UdemyProje1.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UdemyProje1.Draws
{
    public class LineDraw : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        [SerializeField] private LineRendererController _line;

        GameObject _touchedGameObjectForLine,_startPointForLineRenderer,_renderers,_lineTypeObject;
        PcInputController _pcInputController;
        PlayerController _playerController;

        bool _isTouch = false;


        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            
            _pcInputController = new PcInputController();
            _touchedGameObjectForLine = GameObject.FindWithTag("TOUCHEDGAMEOBJECTFORLINE");
            _startPointForLineRenderer = GameObject.FindWithTag("StartPoint");
            _touchedGameObjectForLine.transform.position = new Vector3(0f, -2.42f);
            _renderers = GameObject.FindWithTag("Renderers");
            for(int i = 0; i <= _renderers.transform.childCount - 1; i++)
            {
                if(i!= (int)_playerController.PlayerLevel - 1)
                {
                    _renderers.transform.GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    _lineTypeObject = _renderers.transform.GetChild((int)_playerController.PlayerLevel - 1).gameObject;
                }
            }
            _line = _lineTypeObject.GetComponent<LineRendererController>();

        }
        private void Start()
        {
            _line.SetUpLine(points);
        }
        private void Update()
        {
            if (_pcInputController.TouchCount)
            {
                _isTouch = true;

            }
            else if (!_pcInputController.TouchCount)
            {
                _isTouch = false;
                _touchedGameObjectForLine.transform.position = new Vector3(0f, -2.42f);
                _startPointForLineRenderer.transform.position = new Vector3(0f, -2.42f);
            }
            
        }

        private void FixedUpdate()
        {
            if (_isTouch)
            {
                if(Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -2.42f)
                {
                    _touchedGameObjectForLine.transform.position = new Vector3(0f, -2.42f);
                    _startPointForLineRenderer.transform.position = new Vector3(0f, -2.42f);
                }
                else
                {
                    if ((int)_playerController.PlayerLevel - 1 == 0)
                    {
                        _startPointForLineRenderer.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0.5f, 10f);

                    }
                    if (_touchedGameObjectForLine.transform.position != Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f))
                    {
                        _touchedGameObjectForLine.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);
                        if ((int)_playerController.PlayerLevel - 1 == 4 || (int)_playerController.PlayerLevel - 1 == 3)
                        {
                            float y = _startPointForLineRenderer.transform.position.y - _touchedGameObjectForLine.transform.position.y;
                            float x = _startPointForLineRenderer.transform.position.x - _touchedGameObjectForLine.transform.position.x;

                            float slope = y / x;
                            _startPointForLineRenderer.transform.position = new Vector3(0f, -2.42f) + new Vector3((y / slope) / 3f, (x * slope) / 3f);
                        }
                    }
                }
            }
        }
    }
}

