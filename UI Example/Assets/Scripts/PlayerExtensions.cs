using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

// 使用 C# 的扩展方法
// 官方:
// 扩展方法使您能够向现有类型“添加”方法，而无需创建新的派生类型、重新编译或以其他方式修改原始类型
// 扩展方法被定义为静态方法，但它们是通过实例方法语法进行调用的、它们的第一个参数指定该方法作用于哪个类型，并且该参数以 this 修饰符为前缀

public static class PlayerExtensions {

	public const string ScoreProp = "score";
	public const string SpriteProp = "spriteIndex";

	public static void SetPlayerScore(this PhotonPlayer player, int newScore) {
		Hashtable props = new Hashtable();
		props[PlayerExtensions.ScoreProp] = newScore;
		player.SetCustomProperties(props);
	}

	public static void SetSprite(this PhotonPlayer player, int index) {
		Hashtable props = new Hashtable();
		props[PlayerExtensions.SpriteProp] = index;
		player.SetCustomProperties(props);
	}
}