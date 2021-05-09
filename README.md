# Unity reference project

My reference project for Unity.

## Development prerequisites

- [Git](https://git-scm.com/)
- [Git-LFS](https://git-lfs.github.com/)
- [Unity](https://unity3d.com/unity)
- [Rider](https://www.jetbrains.com/toolbox/) (or other IDE)

## Getting started

- Install the prerequisite software above
- Clone repository

```bash
git clone git@github.com:webbertakken/unity-reference-project.git
cd unity-reference-project
```

- Setup Git LFS

```bash
git lfs install
git config remote.origin.lfsurl https://github.com/webbertakken/unity-reference-project.git/info/lfs
```

> **Note:** git lfs only works with https url. See [git-lfs#1089](https://github.com/git-lfs/git-lfs/issues/1089)

## Setup Unity and Rider

- Open the project folder in Unity
- In Unity goto `Edit` > `Preferences` > `External Tools` > `External Script Editor` > set external editor to an IDE in 
the prerequisites list.
- In Unity open a `.cs` (C#) file, to open the preferred IDE.
- Open the Project View (`View` > `Tool Windows` > `Explorer`) and dock-pin it to the right (or left) of the editor.
- In the project view, instead of the "Unity" use the "File System" scope.
- Open the Version Control View (`View` > `Tool Windows` > `Version Control`) and dock-pin it to the left (or right).


