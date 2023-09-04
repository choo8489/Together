using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BokHead.Together.Base
{
    public abstract class ViewBase : MonoBehaviour
    {
        public abstract void Show(Action onComplete);
        public abstract void Hide(Action onComplete);
    }
}
