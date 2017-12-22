using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 自定义 Button 继承之 Button
// 原 Button 之接收 OnClick 事件
// 增加 Pressed 事件得处理逻辑
// 定义得公共变量需要 Inspector Debug 视图才能显示
public class OnFireButton : Button {

	public PlayerController playerController;
	public RectTransform powerBar;
	public RectTransform powerProgress;

	private float factor = 0;
	private float holdTime = 0;

	void Update() {
		if (IsPressed()) {
			// 叠加按住时间
			holdTime += Time.deltaTime;
			// 让按住时间在 0 到 1 之间徘徊
			factor = Mathf.PingPong(holdTime, 1);
			// powerBar.width * factor = powerProgress 的实时宽度
			powerProgress.sizeDelta = new Vector2(powerBar.sizeDelta.x * factor, powerProgress.sizeDelta.y);
		} else if (holdTime > 0) {
			// power is 0 to 1
			playerController.Fire(factor);
			holdTime = 0;
		}
	}

}