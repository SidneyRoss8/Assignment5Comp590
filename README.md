# Assignment5Comp590

# Assignment 5: Shader Graphs – Lightsaber

## Video
(https://www.youtube.com/watch?v=YVUBQwo-8vs)

## How to Run
1. Open the project in **Unity 6 (6000.5.9f1)** using Unity Hub (Add → select the project folder).
2. Open the scene at `Assets/Scenes/SampleScene`.
3. Press **Play**, then click inside the Game view so it receives keyboard input.
4. Press **Space** to turn the lightsaber off and on.

## Controls
- **Space**: toggle the blade (collapses into the hilt / extends back out)

## What I Built
- **Part 2:** Blade cylinder with an emissive material and Bloom post-processing on the Global Volume.
- **Part 3:** Custom Lit Shader Graph (`BladeShader`) with exposed properties: BladeColor, OuterGlow,
  InnerGlow, and PulseSpeed. It uses Time → Multiply → Noise Sine Wave → Remap to make the
  blade's glow pulse/flicker, then Lerps between the colored glow and the pulse, feeding into Emission.
  All four properties can be adjusted on `Blade material` in the Inspector.
- **Part 4:** `SaberScript.cs` on the `BladeBase` empty object scales the blade along its local y-axis
  so it extends/collapses from the hilt, and deactivates the blade when fully collapsed so no
  artifacts remain. Hierarchy: Lightsaber → Hilt, BladeBase → Blade.
- **Part 5 (Extensions):**
  - A pink Point Light attached to the blade lights up the floor around it and turns off
    automatically when the blade collapses.
  - On/off sound effects play when toggling the blade.

## Notes
- This project uses Unity 6, which uses the **new Input System** by default, so the script uses
  `Keyboard.current.spaceKey.wasPressedThisFrame` instead of `Input.GetKeyDown(KeyCode.Space)`.
- The `Library`, `Temp`, `Logs`, and `UserSettings` folders are not included. Unity regenerates
  them when the project is opened (the first open may take a few minutes).

## Outside Resources
- Assignment 5 instructions (course document)
- Unity Shader Graph & URP documentation
- Claude (AI assistant) for help with project setup, troubleshooting, and the extend/collapse script
