# holoCT_


## Code and Storage <br>
The file structure of the key folders is as follows: <br>
/Assets <br>
<&nbsp> <&nbsp> <&nbsp>/Holograms – The fetal meshes used in the app (in .fbx format)
/Resources - Images, xml files, materials for meshes
/Scripts – The C# scripts for the app
/Scenes – The .unity files that contain the main app scenes
Example .MHIF files and glTF meshes can be found in /MHIF_Cases and
Fetal_Meshes respectively at the root of the source code folder.
• Azure Blob Storage:
Subscription Name: GC99_2017_Caroline Smith
Storage Account: holoctazureblobs (Used in the App for dynamic loading)
Access Key:
Symln2dG9AnLo668i9jjieWZrYuKfyjFSD1KHT/dDYXErNXh9Kj09vkNqh2Qi7p
3no6tug3vA5ZFkAeKlgd8uw==
Container Name: blob
Built With
• Unity 2017.4.1f1.
• Visual Studio 2017: ‘Universal Windows Platform development’ & ‘Game
Development with Unity’ workloads.
76
• Windows 10 Education with SDK update from April 6th 2018, in developer
mode with Hyper-v supported.
• HoloLens Emulator and HoloLens device.
Prerequisites
See Microsoft Mixed Reality Academey for full specification of tools required for
HoloLens development: https://docs.microsoft.com/en-us/windows/mixedreality/
install-the-tools
Dependencies
The following libraries are used in the app and need to be installed via Unity for the app
to function:
• Microsoft’s Mixed reality tool kit for Unity
• RESTClient for Unity.
• StorageServices for Unity.
• UnityGLTFLib (uses JSON.NET plugin for Unity)
Installation & Deployment
Opening in Unity:
• In Unity – select ‘open’ and locate the ‘Holo_Imaging’ app to open in Unity.
• Click on the different scenes to load them and explore. The scene structure is
in figure X.X of this project. All singleton components are in the ‘preload’ scene
including mixed reality camera parent and input manager which are needed in
every scene.
• Enter the azure storage details in the ‘dynamic load’ scene – storage acocunt
name, access key and contiainer needed – see previous page.
Settings:
• With the mixed reality toolkit already in the project, the correct settings for a
mixed reality project can be applied by selecting Mixed Reality Toolkit ->
Configure -> Apply Mixed Reality Project Settings. Important to target for
Windows Universal UWP and enable .net scripting backend.
77
Capabilities:
• The app must declare the appropriate capabilities in its manifest. The settings
are found in Player Settings > Settings for Universal Windows Platform >
Publishing Settings > Capabilities. InternetClient & microphone are needed.
For more information on setting up for mixed reality app:
https://github.com/Microsoft/MixedRealityToolkit-Unity/blob/master/GettingStarted.md
For how to build app to emulator:
https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101e
For how to build app to HoloLens device:
https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101

https://youtu.be/nXyaozmQpT8
