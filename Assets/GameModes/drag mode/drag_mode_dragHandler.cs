using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class drag_mode_dragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {

	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts=false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts=true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
        }
        else
        {
            GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
	}

	#endregion



}
