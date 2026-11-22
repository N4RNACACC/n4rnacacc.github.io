# N4RNACSite

基于 Avalonia UI、.NET 与 TKCode.Arc 构建的跨平台个人站点。界面层与平台宿主相互分离，目前提供可运行的 WebAssembly 浏览器宿主，并为桌面窗口和后续功能扩展保留了共享应用层。

![.NET](https://img.shields.io/badge/.NET-11.0-512BD4?style=for-the-badge)
![Avalonia UI](https://img.shields.io/badge/Avalonia_UI-12.1.6-8A2BE2?style=for-the-badge)
![TKCode.Arc](https://img.shields.io/badge/TKCode.Arc-1.3.0-0F9D58?style=for-the-badge)

> **当前状态**：浏览器版本可直接运行；仓库包含桌面窗口及共享应用逻辑，但尚未包含独立的桌面启动项目。

## 功能

- 使用 Avalonia 与 TKCode.Arc 组件构建统一界面，可复用同一套页面、视图模型和主题系统。
- 提供首页与项目页示例，包含统计卡片、项目列表和“新建项目”交互。
- 支持浅色、深色及跟随系统的外观设置，并持久化主题状态。
- 浏览器宿主使用 `localStorage` 保存用户偏好，刷新页面后仍可恢复。
- 为浏览器内置中文字体子集，避免 WebAssembly 画布环境缺少系统字体时出现方框或缺字。
- 使用 CommunityToolkit.Mvvm 源生成器实现属性通知与命令，避免运行时反射。

## 技术栈

| 组件 | 版本 | 用途 |
| --- | --- | --- |
| .NET | 11.0 | 应用运行时与 WebAssembly 构建 |
| Avalonia UI | 12.1.6 | 跨平台 UI 与 XAML |
| TKCode.Arc | 1.3.0 | 设计令牌、主题与 UI 组件 |
| CommunityToolkit.Mvvm | 8.4.2 | MVVM 属性与命令源生成 |
| SkiaSharp | 4.157.0 | 浏览器端图形渲染 |

## 架构概览

```text
浏览器宿主 / 桌面宿主
        ↓
App + AppSetup
        ↓
MainWindow 或 MainView
        ↓
MainViewModel → PageHost → AppPages → Pages
```

- [`MainView`](N4RNACSite/Views/MainView.axaml) 是共享主界面；桌面宿主管在 `MainWindow` 中，浏览器宿主直接显示该视图。
- [`MainViewModel.SelectedKey`](N4RNACSite/ViewModels/MainViewModel.cs) 驱动页面切换。
- 页面通过 [`AppPages.All`](N4RNACSite/Navigation/AppPages.cs) 显式注册，不依赖反射扫描。
- 各平台宿主可在构建应用前替换 `AppSettings.Store`，从而使用文件、浏览器存储或内存存储。


## License

Copyright (c) 2026 N4RNAC - All Rights Reserved.
