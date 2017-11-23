using UnityEngine;

public class BaseAction : MonoBehaviour
{
    // 继承该类的子类须重写该方法，实现具体的逻辑
    // other 一般是碰撞的另一方
    public virtual void ExecuteAction(GameObject other) { }

}
