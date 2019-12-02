using exam_nasa.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_nasa.Infrastructure
{
    class ServiceLocator
    {
        IKernel kernel;
        public ServiceLocator()
        {
            kernel = new StandardKernel();
        }
        public MainViewModel MainViewModel
        {
            get => kernel.Get<MainViewModel>();
        }
    }
}
