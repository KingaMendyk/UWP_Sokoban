using UnityEngine;

public static class LevelLoader {
    private static char[,] levelArray;

    public static char[,] LoadData(TextAsset textAsset) {
        string[] fileAsStrings = textAsset.text.Split("\n");
        levelArray = new char[fileAsStrings[0].Length - 1, fileAsStrings.Length];
        
        for (int i = fileAsStrings.Length - 1; i >= 0; i--) {
            for (int j = 0; j < fileAsStrings[i].Length - 1; j++) {
                levelArray[i, j] = fileAsStrings[i][j];
            }
        }

        for (int i = 0; i < levelArray.GetLength(0); i++) {
            string m = "";
            for (int j = 0; j < levelArray.GetLength(1); j++) {
                m += levelArray[i, j];
                Debug.Log(levelArray[i, j] + " " + i + " " + j);
            }
            Debug.Log(m);
        }
        
        return levelArray;
    }
}
