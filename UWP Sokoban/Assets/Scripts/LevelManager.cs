using System;
using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public static class LevelManager {
        private static TextAsset textAsset;
        
        public static void SetTextAsset(string textAssetName) {
            try {
                textAsset = new TextAsset(File.ReadAllText(Application.streamingAssetsPath +"/"+ textAssetName + ".txt"));
            }
            catch (Exception e) {
                Debug.LogError(e);
            }
        }

        public static TextAsset GetTextAsset() {
            return textAsset;
        }
    }
}