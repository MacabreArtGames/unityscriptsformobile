using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    Vector2 _lastPosition = Vector2.zero;

    public Events.Vector2 OnSwipeStart = new Events.Vector2();
    public Events.Vector2 OnSwipeEnd = new Events.Vector2();
    public Events.Vector2 OnSwipe = new Events.Vector2();

    public void OnBeginDrag(PointerEventData eventData)
    {
        _lastPosition = eventData.position;
        OnSwipeStart.Invoke(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnSwipeEnd.Invoke(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - _lastPosition;
        _lastPosition = eventData.position;

        OnSwipe.Invoke(direction);
    }
}


/// <summary>
/// Container class for Serializable Events in UnityEditor.
/// </summary>
public static class Events
{

    // Additional event-definitions...

    [Serializable]
    public class Vector2 : UnityEvent<UnityEngine.Vector2> { }
}
