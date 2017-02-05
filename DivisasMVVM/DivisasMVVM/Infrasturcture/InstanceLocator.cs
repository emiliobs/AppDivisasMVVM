using DivisasMVVM.ViewModels;

namespace DivisasMVVM.Infrasturcture
{


    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
