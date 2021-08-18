# File Rename Batch

## 🕔 Build status

| Architeture | Status | Version |
|-------------|--------|---------|
| x64         | Active | 1.0.0   |

<br>

## 📝 About

This is a simple console application that was created to rename multiples 
files in my backup driver. Fell free to use :)


### Languages and tools

<img align="left" alt="Git" width="28px" src="https://cdn.worldvectorlogo.com/logos/git-icon.svg"/>

<br>
<br>

## 🚀 To Do

- [ ] Apply all configurations in .json file;
- [ ] Apply recursive option to read subfolders;
- [ ] Allow keep original file names;
- [ ] Allow multiples folders;

<br>

## 📃 Requirements

To execute this project, you need the version 3.1 or above of [.netcore SDK](https://dotnet.microsoft.com/download). If you already do it, see the next topic.

<br>

## 💻 Instalation

### Add or remove folder

Access the file RenameFileBatch.cs, then add new a new path to variable places.

<code>string places = <your_files_path>;</code>

Obs.: To add new extensions file, add a new item in the list
<code>allowedImageExtensions</code>.

### Linux/Mac

Access the root folder of project from terminal and execute the follows commands:

``` terminal
cd ./src/Presentation && dotnet run
```

### Windows

Access the root folder of project from cmd and execute the follow command:

``` terminal
cd ./src/Presentation && dotnet run 
```
Obs.: If you are using the Windows Terminal as default, the linux commands are allowed to use.

 <br>
  
## 📑 License

This project use the MIT license. See more details [here](LICENCE).
