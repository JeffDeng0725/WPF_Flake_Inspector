using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo1.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationAware
    {
        private readonly IContainerProvider containerProvider;
        public readonly IEventAggregator eventAggregator;
        public NavigationViewModel(IContainerProvider containerProvider)
        {
            this.containerProvider = containerProvider;
            eventAggregator = containerProvider.Resolve<IEventAggregator>();
        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
