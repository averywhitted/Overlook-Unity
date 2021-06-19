# Overlook - Unity Package

Editor tools for creating settings and remotes in Overlook projects.

## Overlook GameObject

You must include a GameObject in the project hierarchy that has the ```GameData.cs``` script on it. 
It is recommended that this be done first and named ```"Overlook"```.

You must also populate the object reference fields in the inspector with ```Settings``` and ```Remotes``` scriptable objects.

## GameData.cs

This script takes all the data from the ```Settings``` and ```Remotes``` scriptable objects and parses it into
a single JSON that is passed to the Overlook platform at runtime. 

## Settings Scriptable Object

This is a data container made from the ```SettingsConfigObject.cs``` script. It can be accessed by right-clicking in 
the Assets panel and navigating to:
```[Create] > [Overlook] > [Settings Config Object]```

This object comes with its own custom editor which can be brought up by clicking the ```Open Settings Editor``` button
in the inspector.

## Remotes Scriptable Object

This is a data container made from the ```RemotesConfigObject.cs``` script. It can be accessed by right-clicking in
the Assets panel and navigating to:
```[Create] > [Overlook] > [Remotes Config Object]```

This object comes with its own custom editor which can be brought up by clicking the ```Open Remotes Editor``` button
in the inspector.

