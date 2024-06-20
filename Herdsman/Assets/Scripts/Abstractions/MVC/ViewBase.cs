using System;
using UnityEngine;

namespace Abstractions.MVC
{
    public abstract class ViewBase<TModel> : MonoBehaviour, IDisposable where TModel : IModel
    {
        protected TModel Model { get; private set; }

        public void Initialize(TModel model)
        {
            Model = model;
            DoInitialize();
        }
        public void Dispose()
        {
            DoDispose();
        }

        protected virtual void DoInitialize()
        {
        }

        protected virtual void DoDispose()
        {
        }
    }
}
