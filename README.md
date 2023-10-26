# AnomalyMod
A mod/cheat for [Anomaly Man](https://game-dawn.itch.io/anomaly-man).

## Building
1. Clone the repo
2. Open the .sln file in Visual Studio (or whatever IDE you prefer for C# development)
3. Add the DLL files found in the `Anomaly Man/Anomaly Man_Data/Managed` folder as dependencies
4. Build the project **for x64**, I cannot confirm if this will work on other platforms
   - **NOTE**: You may need to add a solution platform configuration!

## Injecting
To inject the DLL, you will need [Sharp Mono Injector](https://github.com/wh0am15533/SharpMonoInjector).

After setting up Sharp Mono Injector
1. Select the Anomaly Man process in the Sharp Mono Injector GUI
2. Select the AnomalyMod.dll file
3. Ensure the Namespace is set to `AnomalyMod`
4. Set the Class name to `AnomalyMod`
5. Set the Method name to `Start`
6. (Optional) set the Method name for Eject to `Unload` (You'll need to set the Class name & Namespace to the same thing as Inject)

Finally, you can click the "Inject" button. AnomalyMod will now be injected. You can confirm this by seeing if the AnomalyMod window has appeared.
