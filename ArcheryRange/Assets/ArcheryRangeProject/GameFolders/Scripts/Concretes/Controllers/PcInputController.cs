using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace UdemyProje1.Controllers
{
    public class PcInputController {

        public bool LeftMouseClickDown => Input.GetMouseButtonDown(0);
        public bool LeftMouseClickUp => Input.GetMouseButtonUp(0);
        public bool TouchCount => Input.touchCount > 0;
    }
}

