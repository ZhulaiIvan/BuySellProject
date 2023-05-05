 using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.InputSystem.Layouts;
 using UnityEngine.InputSystem.OnScreen;

 public class OnScreenLookControl : OnScreenControl, IPointerDownHandler, IPointerUpHandler,
            IDragHandler
    {
        [SerializeField] [InputControl(layout = "Vector2")]
        private string m_ControlPath;

        [SerializeField] private RectTransform _transform;
        [SerializeField] private AnimationCurve _horizontalCorrectionCurve;
        [SerializeField] private AnimationCurve _verticalCorrectionCurve;

        private bool active;
        private Vector2 pointerDownPosition, delta;

        protected override string controlPathInternal
        {
            get => m_ControlPath;
            set => m_ControlPath = value;
        }

        private void Awake()
        {
            Enable(false);
        }

        private void Update()
        {
            if (active) 
                SendValueToControl(delta);

            delta = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!active) return;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_transform, eventData.position,
                eventData.pressEventCamera, out Vector2 position);

            Vector2 rawDelta = position - pointerDownPosition;
            delta = new Vector2(
                rawDelta.x * _horizontalCorrectionCurve.Evaluate(Mathf.Abs(rawDelta.x)),
                rawDelta.y * _verticalCorrectionCurve.Evaluate(Mathf.Abs(rawDelta.y)));

            pointerDownPosition = position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_transform, eventData.position,
                eventData.pressEventCamera, out pointerDownPosition);
            Enable(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Enable(false);
            SendValueToControl(Vector2.zero);
        }

        private void Enable(bool flag)
        {
            active = flag;
        }
    }