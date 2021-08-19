# File Rename Batch

## 🕔 Build status

| Architeture | Status | Version |
|-------------|--------|---------|
| x64         | Active | 1.1.0   |

<br>

## 📝 About

This is a console application that was created to rename multiples 
files in my backup driver. Fell free to use :)


### Languages and tools

<img align="left" alt="Git" width="28px" src="https://cdn.worldvectorlogo.com/logos/git-icon.svg"/>

<br>
<br>

## 🚀 To Do

- [x] Apply all configurations in .json file;
- [ ] Apply recursive option to read subfolders;
- [ ] Allow keep original file names;
- [ ] Allow multiples folders;

<br>

## 📃 Requirements

To execute this project, you need the version 3.1 or above of [.netcore SDK](https://dotnet.microsoft.com/download) installed.

<br>

## 💻 Instalation

Open the terminal or CMD and run the follow command to install de pendendecies of project.

``` terminal
cd ./src/Presentation && dotnet restore
```

Then, access the ```setting.json``` and add you chosen folders.

```` json
{
    "Folders": [
        {
            "From": "the_full_path_of_your_files_folder",
            "To": ""
        }
    ]
}
````

After that, run the command bellow:

``` terminal
dotnet run
```

 <br>
  
## 📑 License

This project use the MIT license. See more details [here](LICENCE).
