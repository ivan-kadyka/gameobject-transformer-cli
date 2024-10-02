# gameobject-transformer


C# console application that asynchronously reads unordered transform data for an unknown number of objects.
Generate GameObjects in memory to match this data, then sort the game objects ordered by distance from origin.
The console app should output the result as a serialized data structure.
You will be required to import the unity dll for this, but not the editor library.
This will require a 3d math Library as we assume the positions will be Vector3s. Make sure you import a math library or the UnityEngine dll