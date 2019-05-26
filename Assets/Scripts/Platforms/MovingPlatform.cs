using System;
using System.Collections;
using System.Numerics;
using Tools;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Platforms
{
    public enum MovingAxis
    {
        XAxis,
        YAxis
    }
    
    public class MovingPlatform : BasePlatform
    {
        [MinMaxRange(1f, 3f)]
        public RangedFloat range;

        public FloatReference speed;

        public MovingAxis axis;

        private bool IsEnabled => gameObject.activeSelf;
        public float YRange => axis == MovingAxis.YAxis ? _range : 0f;

        private float _range;
        private Vector3 _target;
        private int _direction;
        private Vector3 Direction
        {
            get
            {
                var vec = Vector3.zero;
                var pos = transform.position;
                switch (axis)
                {
                    case MovingAxis.XAxis:
                        vec = pos.x < _target.x ? Vector3.right : Vector3.left;
                        break;
                    case MovingAxis.YAxis:
                        vec = pos.y < _target.y ? Vector3.up : Vector3.down;
                        break;
                }

                return vec;   
            }
        }

        public override void Init()
        {
            _direction = 1;
            _range = range.Random();
            var pos = transform.position;
            _target = Revert(pos);

            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (IsEnabled)
            {
                while (Vector3.Distance(transform.position, _target) > 0.1)
                {
                    transform.Translate(Direction * speed * Time.deltaTime);
                    
                    yield return null;
                }

                _direction *= -1;
                _target = Revert(_target);
            }
        }

        private Vector3 Revert(Vector3 vector3)
        {
            var newVec3 = vector3;
            
            switch (axis)
            {
                case MovingAxis.XAxis:
                    newVec3.x += _direction * _range;
                    break;
                case MovingAxis.YAxis:
                    newVec3.y += _direction * _range;
                    break;
            }

            return newVec3;
        }
    }
}
