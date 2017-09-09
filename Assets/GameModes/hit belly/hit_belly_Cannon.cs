using UnityEngine;
using System.Collections;

public class hit_belly_Cannon : MonoBehaviour {
    public AudioClip cannon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

    public void FireButton(GameObject bullet)
    {
        if (GameObject.Find("cannon_bullet(Clone)") == null)
        {
            GameObject NewBullet = (GameObject)Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 75, transform.position.z), Quaternion.identity);
            AudioSource.PlayClipAtPoint(cannon, new Vector3(0, 0, 0));
            NewBullet.tag = gameObject.tag;
            Vector2 sizeDelta = NewBullet.transform.GetComponent<RectTransform>().sizeDelta;
            NewBullet.transform.SetParent(GameObject.Find("UpPanel").transform);
            NewBullet.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeDelta.x,sizeDelta.y);
            NewBullet.transform.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }

    }
}
