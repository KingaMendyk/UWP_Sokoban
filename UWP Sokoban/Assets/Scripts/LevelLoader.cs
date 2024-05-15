using UnityEngine;

public static class LevelLoader {
    private static char[,] levelArray;

    public static char[,] LoadData(TextAsset textAsset) {
        string[] textLines = textAsset.text.Split("\r\n");
        levelArray = new char[textLines.Length, textLines[0].Length];

        for (int i = 0; i < levelArray.GetLength(0); i++) {
            textLines[i].TrimEnd();
            for (int j = 0; j < levelArray.GetLength(1); j++) {
                levelArray[i,j] = textLines[i][j];
            }
        }

        return levelArray;
    }
}
