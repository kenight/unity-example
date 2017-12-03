TRex

1.分割图片：Sprite Editor Slice
2.创建图集：创建 Sprite Atlas 打包图集
3.创建网格：将需要绑定骨骼的 Sprite 创建 Sprite Mesh
4.创建 Sprite Mesh Instance 组件：拖拽创建好的 Sprite Mesh 到场景中
5.设置骨骼到 Sprite Mesh 上：创建骨骼架构，并通过 Sprite Mesh Instance 组件的 Set bones 设置需要绑定的骨骼
6.绑定骨骼(蒙皮)：一定在 Set bones 设置好骨骼后，选中该 Sprite Mesh 再打开 SpriteMesh Editor (Window -> Anima2D -> SpriteMesh Editor)
进行绑定与调整权重，绑定完成后将看到 Skinned Mesh Renderer 组件将取代 Mesh Renderer 组件


一些技巧：

* 快速调整网格点
创建 Sprite Mesh 时先使用自动 Slice
待骨骼绑定到 Sprite Mesh 并进入 SpriteMesh Editor 编辑绑定与权重时，即可根据骨骼关节位置调整网格分布

* 复制蒙皮
复制或建立骨架(通常是对称的如：左脚)
拖拽已绑定骨骼的 Sprite Mesh 到场景中
替换 Sprite Mesh Instance 组件的 Bones 列表到第一步的新骨骼

* 一根骨骼可以同时控制多个 Sprite：
比如常见的情况是两个 Sprite 有重叠，完全可以将这两个 Sprite Mesh 绑定一根骨骼，即将两组网格蒙皮到一根骨骼上
同样的，一组骨骼也可以绑定到多个 Sprite Mesh 上，如 TRex 模型中张开的嘴与牙齿