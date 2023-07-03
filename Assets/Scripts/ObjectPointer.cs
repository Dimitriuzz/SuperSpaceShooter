using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SpaceShooter
{
    public class ObjectPointer : MonoBehaviour
    {
        private Vector3 targetPosition;
        private RectTransform pointerRectTransform;
        [SerializeField] GameObject m_TargetObject;

        private void Awake()
        {
            targetPosition = m_TargetObject.transform.position;
            pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        }
        // Update is called once per frame
        void Update()
        {
            Vector3 toPosition = targetPosition;
            Vector3 fromPosition = Camera.main.transform.position;
            fromPosition.z = 0f;
            Vector3 dir = (toPosition - fromPosition).normalized;

        }
    }
}
