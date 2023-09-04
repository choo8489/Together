using UnityEngine;

using Debug = Rito.Debug;

namespace BokHead.Together.MVVM.Main
{
    using BokHead.Together.Base;

    [RequireComponent(typeof(MainView))]
    public class MainViewModel : ViewModelBase
    {
        #region [ Variables Methods ]
        private const string HEADER = "[ MainViewModel ]";

        //private MainModel model;
        private MainView view;

        #endregion

        #region [ Interface Methods ]
        public override void Initialize()
        {
            //model = new MainModel();

            if (!TryGetComponent(out MainView view))
                Debug.LogError($"{HEADER} Can't find view");
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        #endregion
    }
}

