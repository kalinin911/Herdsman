using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Abstractions.MVC
{
    public abstract class ControllerBase<TModel, TView> : IDisposable
        where TModel : IModel
        where TView : ViewBase<TModel>
    {
        protected TModel Model { get; }
        protected TView View { get; }

        public ControllerBase(TModel model)
        {
            Model = model;

            var path = Model.AssetPath;
            var viewObject = Resources.Load<TView>(path);

            View = Object.Instantiate(viewObject);
            View.Initialize(Model);
            DoInitialize();
        }

        protected virtual void DoInitialize()
        {
        }

        public void Dispose()
        {
            View.Dispose();
            Object.Destroy(View);
        }



    }
}
