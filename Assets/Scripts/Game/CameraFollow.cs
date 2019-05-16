using System.Collections;
using UnityEngine;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float smoothSpeed = 0.3f;

        private Vector3 _targetPosition;
        private Vector3 _basePosition;
        private bool _isMoving;
    
        private void Start()
        {
            _basePosition = transform.position;
        
            ResetCamera();
        }

        private void LateUpdate()
        {
            var position = transform.position;
            if (target.position.y <= _targetPosition.y) return;

            var newPos = new Vector3(position.x, target.position.y, position.z);
            FollowTarget(newPos);
        }

        private void FollowTarget(Vector3 targetPos)
        {
            _targetPosition = targetPos;
            if(!_isMoving) StartCoroutine(Follow());
        }

        private IEnumerator Follow()
        {
            _isMoving = true;
            while (Vector3.Distance(transform.position, _targetPosition) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * smoothSpeed);
                yield return null;
            }
            _isMoving = false;
        }

        public void ResetCamera()
        {
            _targetPosition = _basePosition;
            transform.position = _basePosition;
        }
    }
}
