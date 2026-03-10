# PB Launcher

PB Launcher adalah aplikasi **Windows launcher** yang dibuat menggunakan **C# .NET** untuk menjalankan dan mengelola game Point Blank. Launcher ini dapat digunakan untuk memulai game, melakukan pengecekan file, serta mempermudah distribusi client game kepada pemain.

## Features

* Launch game client
* Simple and lightweight interface
* Built using C# .NET Windows Forms
* Easy to customize
* Suitable for private server launcher

## Requirements

* Windows 7 / 8 / 10 / 11
* .NET Framework (sesuai versi project)

## Build Project

1. Clone repository

```
git clone https://github.com/deddybear/pb-launcher.git
```

2. Buka project menggunakan **Visual Studio**

3. Build project

```
Build → Build Solution
```

atau gunakan mode **Release** untuk production

```
Build → Configuration Manager → Release
```

4. File hasil build akan berada di folder:

```
bin/Release/
```

## Run Application

Jalankan file:

```
pb-launcher.exe
```

## Project Structure

```
pb-launcher/
│
├─ bin/            # build output
├─ obj/            # temporary build files
├─ Forms/          # UI Forms
├─ Program.cs      # entry point aplikasi
├─ *.csproj        # project configuration
└─ *.sln           # solution file
```

## Development

Project ini dikembangkan menggunakan:

* C#
* .NET Framework
* Windows Forms
* Visual Studio

## Contributing

Silakan buat **Pull Request** atau **Issue** jika ingin memberikan kontribusi pada project ini.

## License

Project ini dibuat untuk tujuan pembelajaran dan pengembangan launcher game.
