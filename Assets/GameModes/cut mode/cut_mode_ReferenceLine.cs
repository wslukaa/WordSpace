using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cut_mode_ReferenceLine : MonoBehaviour {
	public string label;
	public Vector3 startPoint;
	public Vector3 endPoint;
	public Vector3 mousePos;
	public bool correctnessSetting;
	public bool correctness;
	public EdgeCollider2D _collider;
	public LineRenderer line;
	public List<Vector3> pointsList;
	
	// Use this for initialization
	void Start () {
        startPoint = Camera.main.ViewportToWorldPoint(startPoint);
        endPoint = Camera.main.ViewportToWorldPoint(endPoint);
        correctness = correctnessSetting;
	}
	
	// Update is called once per frame
	void Update() {
		bool collided = false;
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		collided = GameObject.Find ("dLine").GetComponent<cut_mode_DrawLine> ().isIntersect(startPoint,endPoint);
		if (collided)
			correctness = !correctness;
		}

}