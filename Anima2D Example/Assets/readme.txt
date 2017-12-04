--- Anima2D 骨骼动画制作流程 (TRex) ---

1.分割图片
将资源中身体各部位的图片通过 Sprite Editor 工具进行分离(Slice)

2.创建图集
新建 Sprite Atlas 打包图集 (Assets -> Sprite Atlas)

3.创建 Anima2D Sprite Mesh 组件
将需要绑定骨骼的 Sprite 创建为 Sprite Mesh

4.创建 Sprite Mesh Instance 组件
将 Sprite Mesh 拖拽到场景中，会自动绑定 Sprite Mesh Instance 组件
将所有 Sprite Mesh 在场景进行组合，构造出完整的模型，方便下一步建立骨架

5.建立骨架

6.蒙皮
绑定骨架到网格(Sprite Mesh)
通过 Sprite Mesh Instance 组件的 Set bones 指定该网格需要影响的骨骼
打开 SpriteMesh Editor (Window -> Anima2D -> SpriteMesh Editor) 进行绑定骨骼，同时调整网格与权重
Apply 后自动生成 Skinned Mesh Renderer 取代 Mesh Renderer

7.建立 IK
Limb 只能约束两个骨骼
CCD 通过设置 Num Bones 可以约束一组骨骼

8.制作动画


--- Anima2D 组件说明 ---

1.Pose Manager
用于存储 Pose 以及在之后恢复到该 Pose

2.Control
将骨骼绑定到一个空物体上，通过控制空物体的变换来影响骨骼，感觉相当于一个代理
主要用于暴露主要的，需要在动画中进行控制和记录关键帧的骨骼

3.SpriteMesh Animation
用于替换 SpriteMesh Instance 上的 Sprite Mesh
主要用在动画或游戏运行中替换 Sprite Mesh , 如更换表情或换肤

4.IK Group
通过每 LateUpdate 更新 IK 状态
官方: This is useful when you want to specify the execution order of IK elements in runtime
另外发现：在未 Bake 动画之前，虽然 IK 未在动画中有变换，但 runtime 时，IK 约束的骨骼可能有微小移动，使用 IK Group 即可以锁定住 IK
分析原因应该是 LateUpdate 在每帧更新时获取了 IK 的 Transform 并进行赋值，但其 Transform 并未变化，所以在 runtime 时约束住了骨骼


--- 一些总结与技巧 ---

1.建立好骨骼之后，再细调网格
创建 Sprite Mesh 时先使用自动 Slice
待绑定骨骼时进入 SpriteMesh Editor 再进行调整

2.快速复刻一套蒙皮 (用左右腿蒙皮来说明)
复制一组骨架
复制一个蒙皮 (已经蒙好皮的游戏对象,包含 Sprite Mesh Instance 和 Skinned Mesh Renderer)
替换 Sprite Mesh Instance 组件的 Bones 列表为第一步复制的骨架

3.一根骨骼可以同时控制多个 Sprite Mesh