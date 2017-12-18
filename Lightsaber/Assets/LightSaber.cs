using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour {

	public LineRenderer line;
	public Transform start;
	public Transform end;
	public Light spotlight;

	private bool on = true;
	private float offset = 0;
	private Vector3 endPos;
	private float lightRange;

	void Start() {
		endPos = end.localPosition;
	}

	void Update() {
		// Line posision
		line.SetPosition(0, start.position);
		line.SetPosition(1, end.position);

		// Light fluid
		offset = Mathf.PingPong(Time.time, 10);
		line.materials[1].SetTextureOffset("_MainTex", new Vector2(offset * 2, 0));

		// Switch on off
		if (Input.GetKeyDown(KeyCode.Space)) {
			on = !on;
		}

		// Set the new 'end' and 'lightRange'
		if (on) {
			end.localPosition = Vector3.Lerp(end.localPosition, endPos, Time.deltaTime * 5);
			lightRange = Mathf.Lerp(lightRange, 8, Time.deltaTime * 3);
		} else {
			end.localPosition = Vector3.Lerp(end.localPosition, start.localPosition, Time.deltaTime * 5);
			lightRange = Mathf.Lerp(lightRange, 0, Time.deltaTime * 3);
		}

		// Set spot light range
		spotlight.range = lightRange;

	}
}