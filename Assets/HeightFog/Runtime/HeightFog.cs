using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace FingerTip.Volume
{
    public class HeightFog : VolumeComponent
    {
        public ColorParameter fogColor = new ColorParameter(Color.white);
        public ClampedFloatParameter fogHeightMin = new ClampedFloatParameter(0, -200, 300);
        public ClampedFloatParameter fogHeightMax = new ClampedFloatParameter(0, -200, 300);

        public bool IsActive => fogHeightMin.value < fogHeightMax.value;
    }
}
