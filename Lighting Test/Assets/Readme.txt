Demo 同时开启 Realtime GI 与 Baked GI，Color space 设置为 Linear

场景中 Baked Light Left / Right 使用发光材质 Mat_Light_Left/Right ，且材质的 GI 设置为 Baked ，将走 Baked GI 流程 (烘培 lightmaps)

Realtime Light 的 Mode 设置为 Realtime 将走 Realtime GI 流程 (实时计算)

可以看到两种方式同样作用于场景中的物体 (Static GameObject)


添加了一个 Reflection Probe 来获取 Box 内的反射效果 (注意材质需调节 Metallic 与 Smoothness 观察反射效果)
因为默认情况下物体仅使用 Skybox 作为反射源，即物体表面只有反射 Skybox 的效果
在本 Demo 中未设置 Skybox Material 所以 添加的 Reflection Probe 在 Baked 后，只有 Box 内的效果 (如果设置 Skybox 则会同时包含 Skybox 与 Box 的效果)
另外：Reflection Probe Culling Mask 排除掉了 Shpere 的 Layer，即不获取 Shpere 的信息


Reflection Probe 使用教程 https://www.youtube.com/watch?v=GuKHQwGpoGs&t=12s


