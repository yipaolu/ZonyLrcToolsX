using System;
using System.Linq.Expressions;
using ReactiveUI;

namespace ZonyLrcTools.Desktop.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    protected void SubscribeToProperty<TSender, TRet>(TSender sender, Expression<Func<TSender, TRet>> property, Action<TRet> updateGlobalConfigAction)
    {
        sender.WhenAnyValue(property)
            .Subscribe(x =>
            {
                updateGlobalConfigAction(x);
                App.Current.UpdateConfiguration();
            });
    }
}