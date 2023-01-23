# 3D Tiles in Unity

Fork of [Unity3DTiles](https://github.com/NASA-AMMOS/Unity3DTiles).

The project uses __Unity 2020.1.17f1__.

## Display a tileset

- Open the project in Unity
- In `Assets/Examples/Scenes` select the scene `MainWeb`
- In the scene, select the `Tileset`
- In `Tileset Behaviour (Script)`, change the `Url` in `Tileset Options` (the URL should be the URL of the `tileset.json`)
  - If you want to use a local tileset, copy the tileset in the Unity project in `Assets/StreamingAssets` and use `data://my_tileset/tileset.json` as URL
  - To add another tileset, create an empty object in the scene and add the `Tileset Behavior (Script)`. Then set the URL as explained above
- Save and play
  - If the tileset isn't displayed when you are playing, try to move/rotate the camera 

![image](https://user-images.githubusercontent.com/32875283/207844715-67825c05-bf0e-45b3-9ebe-10208249c2b8.png)
