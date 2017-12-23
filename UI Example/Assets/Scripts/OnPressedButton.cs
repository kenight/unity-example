using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 自定义 Button 继承之 Button
// 原 Button 之接收 OnClick 事件
// 增加 Pressed 事件得处理逻辑
// 使用时需要切换 Inspector Debug 视图进行设置
public class OnPressedButton : Button {

	public Controller controller;
	public bool toRight = true;

	void Update() {
		if (IsPressed()) {
			controller.Move(toRight);
		}
	}

}