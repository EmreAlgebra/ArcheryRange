using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProje1.MathHelper
{
    public class MathHelper
    {
        public static float Angle(Vector2 p_vector2)
        {
            return (Mathf.Atan2(p_vector2.y, p_vector2.x) * Mathf.Rad2Deg);
        }

    }
}

