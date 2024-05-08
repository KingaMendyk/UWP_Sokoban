using UnityEngine;

public static class LevelLoader {
    private static char[,] levelArray;

    public static char[,] LoadData(TextAsset textAsset) {
        string[] textLines = textAsset.text.Split("\r\n");
        levelArray = new char[textLines[0].Length, textLines.Length];
        
        for (int i = 0; i < textLines.Length; i++) {
            textLines[i].TrimEnd();
            for (int j = 0; j < textLines[i].Length; j++) {
                levelArray[i,j] = textLines[i][j];
            }
        }
        
        return levelArray;
    }
}
