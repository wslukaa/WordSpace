using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class drag_mode_slot : MonoBehaviour, IDropHandler  {

    int count = 0;
    public AudioClip correct1;
    public AudioClip correct2;

    #region IDropHandler implementation

    public void OnDrop (PointerEventData eventData)
	{
        drag_mode_dragHandler.itemBeingDragged.transform.SetParent(transform.parent);
		this.transform.SetAsLastSibling ();

	}
	#endregion

    public void FixedUpdate()
    {
        int number = GameObject.FindGameObjectsWithTag("drag_mode_component").GetLength(0);
        if (transform.parent.childCount== number + 2)
        {
            if (count == 0) {
                PlayCorrectSound();
            }
            count++;
            if(count>=40)
            GameModeHandler.loadnextlevel();
        }
    }

    void PlayCorrectSound()
    {
        if (Mathf.RoundToInt(Random.value) == 0)
        {
            AudioSource.PlayClipAtPoint(correct1, new Vector3(0, 0, 0));
        }
        else
        {
            AudioSource.PlayClipAtPoint(correct2, new Vector3(0, 0, 0));
        }
    }

}
