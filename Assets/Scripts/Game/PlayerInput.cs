using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class PlayerInput : MonoBehaviour
    {
#if UNITY_ANDROID
        public RectTransform leftRect;
        public RectTransform rightRect;
        public float maxTimeHold = 0.5f;
        public AnimationCurve holdCurve;

        private readonly float[] _touchesHoldValue = new float[2];
        
        public float Horizontal {
            get
            {
                var value = 0f;
                var rightValue = RectTransformTouchValue(rightRect);
                var leftValue = RectTransformTouchValue(leftRect);
                value += rightValue;
                value -= leftValue;
                return value;
            }
        }

        private float RectTransformTouchValue(RectTransform rectTransform)
        {
            var value = 0f;
            for (var i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.GetTouch(i);
                var isTouching = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touch.position);
                if (!isTouching) continue;

                value += GetHoldValue(_touchesHoldValue[i]);
            }

            return Mathf.Clamp01(value);
        }

        private float GetHoldValue(float timeHold)
        {
            return holdCurve.Evaluate(Mathf.Clamp01(timeHold / maxTimeHold));
        }

        private void Update()
        {
            for (var i = 0; i < Input.touchCount && i < _touchesHoldValue.Length; i++)
            {
                var touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Ended)
                {
                    _touchesHoldValue[i] = 0f;
                }
                else
                { 
                    var deltaTime = touch.deltaTime;
                    _touchesHoldValue[i] += deltaTime;
                }
            }
        }
#else
        public float Horizontal => Input.GetAxis("Horizontal");
#endif
    }
}
