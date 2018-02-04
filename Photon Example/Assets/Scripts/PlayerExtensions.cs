using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

// 使用 C# 的扩展方法
// 官方:
// 扩展方法使您能够向现有类型“添加”方法，而无需创建新的派生类型、重新编译或以其他方式修改原始类型
// 扩展方法被定义为静态方法，但它们是通过实例方法语法进行调用的、它们的第一个参数指定该方法作用于哪个类型，并且该参数以 this 修饰符为前缀

public static class PlayerExtensions {

	public const string KillProp = "kill";
	public const string DeadProp = "dead";
	public const string SpriteProp = "spriteIndex";

	public static void AddKill(this PhotonPlayer player, int num) {
		int current = player.GetKill();
		current += num;
		Hashtable props = new Hashtable();
		props[KillProp] = current;
		player.SetCustomProperties(props); // SetCustomProperties 会将多个 new Hashtable 转换为字符串键值对并封装在一起（player.CustomProperties）
	}

	public static void AddDead(this PhotonPlayer player, int num) {
		int current = player.GetDead();
		current += num;
		Hashtable props = new Hashtable();
		props[DeadProp] = current;
		player.SetCustomProperties(props);
	}

	public static int GetKill(this PhotonPlayer player) {
		object number;
		if (player.CustomProperties.TryGetValue(KillProp, out number))
			return (int) number;
		return 0;
	}

	public static int GetDead(this PhotonPlayer player) {
		object number;
		if (player.CustomProperties.TryGetValue(DeadProp, out number))
			return (int) number;
		return 0;
	}

	public static void SetSprite(this PhotonPlayer player, int index) {
		Hashtable props = new Hashtable();
		props[PlayerExtensions.SpriteProp] = index;
		player.SetCustomProperties(props);
	}
}