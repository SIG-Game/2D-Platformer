using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor.Tilemaps
{
    internal enum ETilesMenuItemOrder
    {
        AnimatedTile = 2
    }
    
    static internal partial class AssetCreation
    {
        
        [MenuItem("Assets/Create/2D/Tiles/Animated Tile",  priority = (int) ETilesMenuItemOrder.AnimatedTile)]
        static void CreateAnimatedTile()
        {
            ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<AnimatedTile>(), "New Animated Tile.asset");
        }
    }
}
