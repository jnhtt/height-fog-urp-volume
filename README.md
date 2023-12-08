# height-fog-urp-volume

# 日本語
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


# English

Draw the effect of height fog in ScreenSpace.
Since it is PostProcessing, there is no need to make any changes to the shader of the object drawing, but since all pixels are calculated, there is a certain amount of workload.

## Environment

|  | Version |
| --- | --- |
| Unity | 2022.3.14f1 |
| Universal RP | 14.0.9 |

## Setup

1. Add the HeightFogRendererFeature to the Renderer Features in the UniversalRenderer Data.
2. Add HeightFog to the Volume (Global setting) in the Scene.
3. Set FogColor, FogHeightMin, and FogHeightMax.
4. The gradient of Fog occurs between FogHeightMin and FogHeightMax.
5. FogHeightMin below is stained with FogColor.


