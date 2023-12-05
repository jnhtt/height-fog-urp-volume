using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace FingerTip.Volume
{
    public sealed class HeightFogRendererFeature : ScriptableRendererFeature
    {
        private sealed class HeightFogRenderPass : ScriptableRenderPass
        {
            private const string RenderPassName = nameof(HeightFogRenderPass);
            private Material material;

            private static readonly int FogColorId = Shader.PropertyToID("_FogColor");
            private static readonly int FogHeightMinId = Shader.PropertyToID("_FogHeightMin");
            private static readonly int FogHeightMaxId = Shader.PropertyToID("_FogHeightMax");

            public HeightFogRenderPass()
            {
                renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

                var shaderName = "Custom/HeightFog";
                var shader = Shader.Find(shaderName);
                if (shader == null)
                {
                    Debug.LogError($"Not found shader!{shaderName}");
                    return;
                }

                material = CoreUtils.CreateEngineMaterial(shader);
            }

            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                if (renderingData.cameraData.camera.cameraType == CameraType.Preview)
                {
                    return;
                }
                if (material == null || !renderingData.cameraData.postProcessEnabled)
                {
                    return;
                }

                var volumeStack = VolumeManager.instance.stack;
                if (volumeStack == null)
                {
                    return;
                }

                var heightFog = volumeStack.GetComponent<HeightFog>();
                if (heightFog == null || !heightFog.active || !heightFog.IsActive)
                {
                    return;
                }

                material.SetColor(FogColorId, heightFog.fogColor.value);
                material.SetFloat(FogHeightMinId, heightFog.fogHeightMin.value);
                material.SetFloat(FogHeightMaxId, heightFog.fogHeightMax.value);

                var cmd = CommandBufferPool.Get(RenderPassName);
                Blit(cmd, ref renderingData, material);
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }

            public void Cleanup()
            {
                CoreUtils.Destroy(material);
            }
        }

        private HeightFogRenderPass rendererPass;

        public override void Create()
        {
            rendererPass = new HeightFogRenderPass();
        }

        protected override void Dispose(bool disposing)
        {
            rendererPass.Cleanup();
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(rendererPass);
        }
    }
}

