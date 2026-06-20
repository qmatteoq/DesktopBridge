# Desktop Bridge (Project Centennial) samples

A set of step-by-step samples that show how to bring a classic Win32 / .NET desktop
application to the Universal Windows Platform using the **Desktop Bridge** (codename
*Project Centennial*) — packaging an existing desktop app as an APPX/MSIX package and
then progressively enhancing it with UWP APIs.

> **Historical sample.** These projects target the original Desktop Bridge tooling
> (Desktop App Converter) on Windows 10. The modern equivalent is **MSIX packaging**
> with the Windows App SDK. The repo is kept as a reference for the concepts, which
> still apply.

## What's included

The numbered folders are meant to be explored in order, each building on the previous one:

| Folder | What it demonstrates |
| --- | --- |
| `1. Desktop App Converter` | Packaging a classic Win32 app into an APPX package with the Desktop App Converter, including a Windows Forms app that writes to the registry and file system. |
| Following steps | Manually packaging the app, declaring the package manifest, and lighting it up with UWP features (live tiles, app services, background tasks) from a Win32 process. |

## Prerequisites

- Windows 10 (1607+)
- Visual Studio 2017 with the **Universal Windows Platform development** workload
- Windows 10 SDK
- Desktop App Converter (for the converter sample)

## Getting started

1. Clone the repository.
2. Open the solution inside the step folder you want to explore in Visual Studio.
3. Set the packaging project as the startup project and run (F5) to deploy the packaged app.

## License

Released under the [MIT License](LICENSE).
