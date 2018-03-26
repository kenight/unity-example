using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {

	LineRenderer line;
	float maxDistance = 15f;
	float timer = 0, frequency = 0.2f;
	int limit = 35;

	void Start() {
		line = GetComponent<LineRenderer>();
		// 射线从碰撞体内部发出时，不检查与自身得碰撞
		Physics2D.queriesStartInColliders = false;
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer >= frequency) {
			DrawLaser();
			timer = 0;
		}
	}

	void DrawLaser() {
		int posCount = 1;
		bool active = true;
		// first point position and direction
		Vector3 lastLaserPos = transform.position;
		Vector3 lastLaserDir = transform.right;
		// first point
		line.positionCount = 1;
		line.SetPosition(0, transform.position);

		while (active) {
			// extend the line segment
			posCount++;
			line.positionCount = posCount;

			RaycastHit2D hit = Physics2D.Raycast(lastLaserPos, lastLaserDir, maxDistance, 1 << LayerMask.NameToLayer("Block"));
			if (hit.collider != null) {
				// if hit something then bouncing the laser
				line.SetPosition(posCount - 1, hit.collider.transform.position);
				// change origin position for next raycast
				lastLaserPos = hit.collider.transform.position;
				// store last dir
				Vector3 prevLaserDir = lastLaserDir;
				// change direction for next raycast
				lastLaserDir = Vector3.Reflect(lastLaserDir, hit.normal);

				// add split laser
				if (hit.collider.tag == "Split") {
					Laser splitLaser = hit.transform.Find("Laser").GetComponent<Laser>();
					splitLaser.enabled = true; // default should be false
					splitLaser.transform.eulerAngles = prevLaserDir;
				}
			} else {
				// no bounce
				line.SetPosition(posCount - 1, lastLaserPos + lastLaserDir * maxDistance);
				active = false;
			}
			if (posCount > limit)
				active = false;
		}

	}

}