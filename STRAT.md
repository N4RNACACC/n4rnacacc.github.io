## 快速开始

### 环境要求

- [.NET SDK 11.0.100](https://dotnet.microsoft.com/download) 或 11.0 版本线中可用的更高 SDK。
- .NET WebAssembly 构建工具 `wasm-tools`。
- ASP.NET Core HTTPS 开发证书。
- 支持 WebAssembly 的现代浏览器。
- 首次还原 NuGet 包时需要网络连接。

仓库中的 [`global.json`](global.json) 以 11.0.100 为最低版本，并允许在同一 11.0 版本线内前滚到较新的功能版本。

首次使用浏览器宿主时安装 WebAssembly 工作负载：

```bash
dotnet workload install wasm-tools
```

首次使用建议配置本地 HTTPS 开发证书：

```bash
dotnet dev-certs https --trust
```

Windows 和 macOS 可能会弹出证书信任确认；请确认安装当前开发证书。

还原依赖并启动应用：

```bash
dotnet restore N4RNACSite.slnx
dotnet run --project N4RNACSite.Browser/N4RNACSite.Browser.csproj
```

命令执行后，在浏览器中打开终端输出的本地地址。首次启动需要下载并编译 WebAssembly 资源，通常会比后续启动慢。

如果不想信任开发证书，可通过 `ASPNETCORE_URLS` 环境变量改用 HTTP：

```powershell
$env:ASPNETCORE_URLS = "http://localhost:5000"
dotnet run --project N4RNACSite.Browser/N4RNACSite.Browser.csproj
```

Linux 或 macOS 可运行：

```bash
ASPNETCORE_URLS=http://localhost:5000 dotnet run --project N4RNACSite.Browser/N4RNACSite.Browser.csproj
```

### 构建与发布

构建整个解决方案：

```bash
dotnet build N4RNACSite.slnx --nologo
```

生成浏览器发布产物：

```bash
dotnet publish N4RNACSite.Browser/N4RNACSite.Browser.csproj -c Release
```

默认发布目录为：

```text
N4RNACSite.Browser/bin/Release/net11.0-browser/publish/
```

发布目录需要通过 HTTP(S) 静态文件服务器访问。直接双击 `index.html` 无法正确加载 WebAssembly 和 JavaScript 模块。

当前 [`index.html`](N4RNACSite.Browser/wwwroot/index.html) 使用 `<base href="/">`，默认适合部署在域名根路径。若部署到 GitHub Pages 项目站点等子路径，需要同步修改 `base href` 和静态资源路径。

## 项目结构

| 路径 | 说明 |
| --- | --- |
| [`N4RNACSite/`](N4RNACSite/) | 共享应用层、页面、视图、视图模型、模型与设置存储。 |
| [`N4RNACSite/App.cs`](N4RNACSite/App.cs) | 应用入口逻辑，并创建桌面窗口或单视图宿主。 |
| [`N4RNACSite/AppSetup.cs`](N4RNACSite/AppSetup.cs) | Avalonia、字体、TKCode.Arc 和初始主题配置。 |
| [`N4RNACSite/Pages/`](N4RNACSite/Pages/) | 首页与项目页的 XAML 及代码隐藏文件。 |
| [`N4RNACSite/Navigation/AppPages.cs`](N4RNACSite/Navigation/AppPages.cs) | 页面注册表，维护页面键、标题和创建方式。 |
| [`N4RNACSite/Navigation/PageHost.cs`](N4RNACSite/Navigation/PageHost.cs) | 页面宿主；页面首次打开后会被缓存。 |
| [`N4RNACSite/Settings/`](N4RNACSite/Settings/) | 主题、窗口位置和偏好设置的持久化逻辑。 |
| [`N4RNACSite.Browser/`](N4RNACSite.Browser/) | WebAssembly 宿主、浏览器设置存储和静态资源。 |
| [`N4RNACSite.Browser/wwwroot/`](N4RNACSite.Browser/wwwroot/) | 浏览器入口页面、启动脚本和 JavaScript 互操作代码。 |
| [`N4RNACSite.slnx`](N4RNACSite.slnx) | 解决方案文件。 |