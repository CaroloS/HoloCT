# HoloCT

A medical imaging holographic application for viewing CT data in Microsoft's HoloLens device and dynamically loaded holographic 'cases' from blob storage. <br>
Holographic cases are in XML format with mesh data stored in GTLF2 format, compressed in base 64.<br>

Video demonstration here: <br>
https://youtu.be/nXyaozmQpT8 <br>

## Code and Storage <br>
Key files are in the assets folder, with the following structure: <br>
/Assets <br>
&nbsp;&nbsp;&nbsp;&nbsp;/Holograms – The fetal meshes used in the app (in .fbx format) <br>
&nbsp;&nbsp;&nbsp;&nbsp;/Resources - Images, xml files, materials for meshes <br>
&nbsp;&nbsp;&nbsp;&nbsp;/Scripts – The C# scripts for the app <br>
&nbsp;&nbsp;&nbsp;&nbsp;/Scenes – The .unity files that contain the main app scenes <br>

Example .MHIF (medical holographic interchange format) files and glTF meshes can be found in /MHIF_Cases <br>

## Built With
• Unity 2017.4.1f1. <br>
• Visual Studio 2017: ‘Universal Windows Platform development’ & ‘Game
Development with Unity’ workloads. <br>
• Windows 10 Education with SDK update from April 6th 2018, in developer
mode with Hyper-v supported. <br>
• HoloLens Emulator and HoloLens device. <br>

## Prerequisites
See Microsoft Mixed Reality Academey for full specification of tools required for
HoloLens development: https://docs.microsoft.com/en-us/windows/mixedreality/install-the-tools <br>

## Dependencies
The following libraries are used in the app and need to be installed via Unity for the app
to function: <br>
• <a href= https://github.com/Microsoft/MixedRealityToolkit> Microsoft’s Mixed reality tool kit for Unity </a><br>
• <a href= https://github.com/Unity3dAzure/RESTClient> RESTClient for Unity. </a><br>
• <a href= https://github.com/Unity3dAzure/StorageServices> StorageServices for Unity. </a><br>
• <a href= https://github.com/deadlyfingers/UnityGLTFLib> UnityGLTFLib (uses JSON.NET plugin for Unity)</a> <br>

Azure Blob Storage is also required for dynamically loading meshes. Once set up - enter storage account name, container name and key in the 'dynamic' scene. 

## Installation & Deployment
<strong> Opening in Unity: </strong> <br>
• Download or clone this repository. In Unity – select ‘open’ and locate the ‘HoloCT’ folder to open in Unity. <br>
• Click on the different scenes to load them and explore. All singleton components are in the ‘preload’ scene
including mixed reality camera parent and input manager which are needed in
every scene. <br>
• Enter the azure storage details in the ‘dynamic load’ scene – storage acocunt
name, access key and contiainer needed.  <br>
<strong>Build Settings: </strong><br>
• With the mixed reality toolkit already in the project, the correct settings for a
mixed reality project can be applied by selecting Mixed Reality Toolkit ->
Configure -> Apply Mixed Reality Project Settings. Important to target for
Windows Universal UWP and enable .net scripting backend.
• Add all the scenes to the build by going to file -> build settings, add open scenes. Preload scene should be the first scene (0) and menu should be second (1). 
<strong>Capabilities</strong><br>
• The app must declare the appropriate capabilities in its manifest. The settings
are found in Player Settings > Settings for Universal Windows Platform >
Publishing Settings > Capabilities. InternetClient & microphone are needed. <br><br>

For more information on setting up for mixed reality app: <br>
https://github.com/Microsoft/MixedRealityToolkit-Unity/blob/master/GettingStarted.md <br>
For how to build app to emulator: <br>
https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101e <br>
For how to build app to HoloLens device: <br>
https://docs.microsoft.com/en-us/windows/mixed-reality/holograms-101 <br>

