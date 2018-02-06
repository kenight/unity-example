1.加入 AR 相机
GameObject -> Vuforia -> AR Camera
并根据提示导入相关资源

2.启用 Vuforia 支持
PlayerSettings -> XR Settings -> Vuforia Augmented Reality Supported

3.App License Key
ARCamera -> Vuforia Behaviour -> Open Vuforia configuration
复制 developer.vuforia.com 的 license key 到配置中

4.准备数据
添加识别图片到线上数据库中，并下载数据库导入到 unity 项目中
在 Vuforia configuration 中启用导入的数据库并使其为激活状态(勾选 Load XXX Database / Activate)