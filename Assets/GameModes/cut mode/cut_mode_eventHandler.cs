using UnityEngine;
using System.Collections;

public class cut_mode_eventHandler : MonoBehaviour {
	public bool triggerAnimation = false;
    private long frequency=0;
    public AudioClip correct1;
    public AudioClip correct2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = Input.mousePosition;
        float x = Camera.main.ScreenToViewportPoint(v).x;
        float y = Camera.main.ScreenToViewportPoint(v).y;
        float z = Camera.main.ScreenToViewportPoint(v).z;
        Debug.Log(x+"  "+y+"  "+z);
        if (triggerAnimation == true)
        {
            frequency = frequency + 1;
            if (frequency % 10 == 0)
            {
                if (GetComponent<CanvasGroup>().alpha == 0)
                    GetComponent<CanvasGroup>().alpha = 1;
                else
                    GetComponent<CanvasGroup>().alpha = 0;
            }
            if (frequency >= 60)
            {
                GameModeHandler.loadnextlevel();
            }
        }
    }

    public void PlayCorrectSound() {
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
