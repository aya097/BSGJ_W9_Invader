using UnityEngine;

namespace Invader.Utility
{
    /// <summary>
    /// Screenに関する便利クラス
    /// </summary>
    public static class ScreenInfo
    {
        /// <summary>
        /// スクリーンの単位座標からワールド座標取得
        /// </summary>
        /// <param name="viewport">0~1:左下基準</param>
        /// <returns></returns>
        public static Vector2 GetPositionByScreen(Vector2 viewport)
        {
            return Camera.main.ViewportToWorldPoint(viewport);
        }
    }
}