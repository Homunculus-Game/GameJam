using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerMoveHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBegin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        // transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEnd");

    }

    public void OnPointerMove(PointerEventData eventData)
    {

        transform.position = eventData.position;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
