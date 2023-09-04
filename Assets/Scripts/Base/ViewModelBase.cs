using UniRx;
using UnityEngine;
using Zenject;

namespace BokHead.Together.Base
{
    public abstract class ViewModelBase : MonoBehaviour
    {
        #region [ Properties ]
        protected CompositeDisposable Disposables { get; private set; }
        #endregion

        #region [ Inject Method ]
        [Inject]
        private void InjectInstaller()
        {
            if (Disposables == null)
                Disposables = new CompositeDisposable();
        }
        #endregion

        #region [ MonoBehaviour Messages ]
        private void OnDestroy()
        {
            Dispose();
        }
        #endregion

        #region [ Interface Mehotds ]
        public abstract void Initialize();

        public virtual void Dispose()
        {
            if (Disposables != null && Disposables.IsDisposed == false)
                Disposables.Clear();
        }
        #endregion
    }
}
