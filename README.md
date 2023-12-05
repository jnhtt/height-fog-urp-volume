# height-fog-urp-volume

ScreenSpaceで高さフォグの効果を描画します。
PostProcessingなのでオブジェクト描画のシェーダーに変更を加える必要はありませんが、全ピクセルが計算対象なのでそれなりの負荷があります。

## 環境

|  | Version |
| --- | --- |
| Unity | 2022.3.14f1 |
| Universal RP | 14.0.9 |

## セットアップ

1. UniversalRenderer Data の Renderer Features に HeightFogRendererFeatureを追加します。
2. SceneにあるVolume(Global設定)にHeightFogを追加します。
3. FogColorとFogHeightMin、FogHeightMaxを設定します。
4. Fogのグラデーションは、FogHeightMinとFogHeightMaxの間で発生します。
5. FogHeightMin以下はFogColorで染まります。


