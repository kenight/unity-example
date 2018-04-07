using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 4f;
	public float perfectOffset = 0.1f;
	public int perfectCount = 5;
	public float increase = 0.1f; // when perfectCombo larger than perfectCount then increase x and y
	public ObjectPool rubblePool;

	[HideInInspector]
	public int score = 0;

	TheStackPool pool;
	Transform prevStack, topStack;
	bool isMoveOnX = true, gameover = false;
	float movingTimer = 0, spawnOffset = 3f;
	int perfectCombo = 0;

	void Start() {
		pool = TheStackPool.instance;

		isMoveOnX = Random.Range(0, 10) >= 5 ? true : false;
		SpawnToptack();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			if (PlaceTopStack()) {
				SpawnToptack();
			} else {
				Gameover();
			}
		}
		// only move the top stack at every frame
		MovingTopStack();
	}

	void SpawnToptack() {
		prevStack = pool.FirstStack().transform;
		topStack = pool.ReuseStack().transform;
		topStack.localScale = prevStack.localScale;
		// 根据移动方向初始化位置
		if (isMoveOnX)
			topStack.position = new Vector3(-spawnOffset, prevStack.position.y + topStack.GetComponent<Stack>().SingleHeight(), prevStack.position.z);
		else
			topStack.position = new Vector3(prevStack.position.x, prevStack.position.y + topStack.GetComponent<Stack>().SingleHeight(), spawnOffset);
		// 重置计时器
		movingTimer = 0;
	}

	void MovingTopStack() {
		if (gameover)
			return;
		// 移动 Stack, 在初始位置的基础上，只改变 x 或 z 坐标
		movingTimer += Time.deltaTime;
		if (isMoveOnX)
			topStack.position = new Vector3(Mathf.PingPong(movingTimer * moveSpeed, spawnOffset * 2) - spawnOffset, topStack.position.y, prevStack.position.z);
		else
			topStack.position = new Vector3(prevStack.position.x, topStack.position.y, -(Mathf.PingPong(movingTimer * moveSpeed, spawnOffset * 2) - spawnOffset));
	}

	bool PlaceTopStack() {
		if (isMoveOnX) { // 只在 X 分量上起变化
			float deltaPos = topStack.position.x - prevStack.position.x;
			float remainScale = prevStack.localScale.x - Mathf.Abs(deltaPos);
			// 放置完成后 topStack 的大小
			Vector3 newTopStackScale = new Vector3(remainScale, topStack.localScale.y, topStack.localScale.z);
			// 放置完成后 topStack 的位置
			Vector3 newTopStackPos = new Vector3(prevStack.position.x + deltaPos / 2, topStack.position.y, topStack.position.z);
			// 生成碎块的大小
			Vector3 rubbleScale = new Vector3(Mathf.Abs(deltaPos), topStack.localScale.y, topStack.localScale.z);
			// 碎块的位置计算，可以理解为将碎块移动到上一块 prevStack 的边缘
			// 在 prevStack 某一轴坐标位置的基础上 + prevStack 大小的一半 + 碎块本身大小的一半 (碎块在本体右边的情况，如在左边则是减去)
			Vector3 rubblePos = new Vector3(Mathf.Sign(deltaPos) > 0 ?
				prevStack.position.x + prevStack.localScale.x / 2 + rubbleScale.x / 2 :
				prevStack.position.x - prevStack.localScale.x / 2 - rubbleScale.x / 2,
				topStack.position.y, topStack.position.z);
			return PlaceAndCreateRubble(deltaPos, remainScale, newTopStackScale, newTopStackPos, rubbleScale, rubblePos);
		} else { // 只在 Z 分量上起变化
			float deltaPos = topStack.position.z - prevStack.position.z;
			float remainScale = prevStack.localScale.z - Mathf.Abs(deltaPos);
			Vector3 newTopStackScale = new Vector3(topStack.localScale.x, topStack.localScale.y, remainScale);
			Vector3 newTopStackPos = new Vector3(topStack.position.x, topStack.position.y, prevStack.position.z + deltaPos / 2);
			Vector3 rubbleScale = new Vector3(topStack.localScale.x, topStack.localScale.y, Mathf.Abs(deltaPos));
			Vector3 rubblePos = new Vector3(topStack.position.x, topStack.position.y,
				Mathf.Sign(deltaPos) > 0 ?
				prevStack.position.z + prevStack.localScale.z / 2 + rubbleScale.z / 2 :
				prevStack.position.z - prevStack.localScale.z / 2 - rubbleScale.z / 2);
			return PlaceAndCreateRubble(deltaPos, remainScale, newTopStackScale, newTopStackPos, rubbleScale, rubblePos);
		}
	}

	bool PlaceAndCreateRubble(float deltaPos, float remainScale, Vector3 newTopStackScale, Vector3 newTopStackPos, Vector3 rubbleScale, Vector3 rubblePos) {
		// 游戏结束
		if (remainScale <= 0)
			return false;

		// 放置 Stack
		if (Mathf.Abs(deltaPos) <= perfectOffset) { // 完美
			perfectCombo++;
			if (perfectCombo > perfectCount)
				topStack.localScale = new Vector3(topStack.localScale.x + increase, topStack.localScale.y, topStack.localScale.z + increase);
			// 使 x,y 坐标重合
			topStack.position = new Vector3(prevStack.position.x, topStack.position.y, prevStack.position.z);
		} else { // 普通
			perfectCombo = 0;
			// 重置 Stack 大小及位置
			topStack.localScale = newTopStackScale;
			topStack.position = newTopStackPos;
			// 生成掉落的碎块
			GameObject rubble = rubblePool.InstantiateFromPool(rubblePos, Quaternion.identity);
			rubble.GetComponent<Rigidbody>().velocity = Vector3.zero;
			rubble.transform.localScale = rubbleScale;
		}

		isMoveOnX = !isMoveOnX;
		return true;
	}

	void Gameover() {
		gameover = true;
		topStack.gameObject.AddComponent<Rigidbody>();
		Debug.Log("Gameover");
	}
}