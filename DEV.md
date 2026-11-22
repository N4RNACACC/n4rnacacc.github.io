## 开发指南

### 添加页面

1. 在 `N4RNACSite/Pages/` 中创建页面视图与对应的视图模型。已安装 Arc 模板时，可先运行 `dotnet new tkcode-arc-page`。
2. 在 [`AppPages.cs`](N4RNACSite/Navigation/AppPages.cs) 的 `All` 注册表中添加入口。
3. 在 [`MainView.axaml`](N4RNACSite/Views/MainView.axaml) 的导航控件中添加相同 `Value` 的选项。

```csharp
public const string About = "about";

new(About, "关于", () => new AboutPage { DataContext = new AboutPageViewModel() }),
```

```xml
<arc:SegmentedOption Value="about" Label="关于" />
```

### 接入真实数据

项目列表示例数据位于 [`Models/Project.cs`](N4RNACSite/Models/Project.cs)，页面状态由 [`ProjectsPageViewModel`](N4RNACSite/ViewModels/ProjectsPageViewModel.cs) 管理。可以将示例集合替换为数据库、REST API 或本地文件数据源；当前新增的项目只保存在内存中，刷新后会重置。

### 修改字体与主题

- 浏览器中文字体位于 [`N4RNACSite.Browser/Assets/Fonts/`](N4RNACSite.Browser/Assets/Fonts/)，由 [`CjkFont.cs`](N4RNACSite.Browser/CjkFont.cs) 注册。
- 启动主题和 Arc 配置位于 [`AppSetup.cs`](N4RNACSite/AppSetup.cs)。
- 运行时主题状态由 [`AppSettings.cs`](N4RNACSite/Settings/AppSettings.cs) 跟踪并保存。
- 更新 Avalonia 包时，应同步升级所有 Avalonia 相关包；TKCode.Arc 针对特定 Avalonia 版本构建。

## 设置存储

浏览器版本使用以下 `localStorage` 键：

```text
N4RNACSite.settings
```

启用桌面宿主后，默认设置文件位于 `<系统应用数据目录>/N4RNACSite/settings.json`。Windows 下的路径为：

```text
%APPDATA%\N4RNACSite\settings.json
```

设置文件损坏或读取失败时，应用会使用默认值继续启动，并在下一次保存时覆盖旧内容。