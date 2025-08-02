using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private PlaceForBar _place;
    [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _rectTransform;

    private void OnEnable()
    {
        _health.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeValue;
    }

    private void Update()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(_camera, _place.transform.position);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform,
            screenPoint,
            _camera,
            out Vector2 localPoint
        );

        _rectTransform.anchoredPosition = localPoint;
    }

    public void ChangeValue()
    {
        _slider.value = _health.Value / _health.MaxValue;
    }
}