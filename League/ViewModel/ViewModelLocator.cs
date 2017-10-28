/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:League"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace League.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<NinjaListVM>();
        }

        public NinjaListVM GetNinjaList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NinjaListVM>();
            }
        }

        public EquipmentListVM GetEquipmentList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EquipmentListVM>();
            }
        }

        public CategoryListVM GetCategoryList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CategoryListVM>();
            }
        }

        public AddNinjaVM GetAddNinjaVM
        {
            get
            {
                return new AddNinjaVM(GetNinjaList);
            }
        }

        public AddEquipmentVM GetAddEquipmentVM
        {
            get
            {
                return new AddEquipmentVM(GetEquipmentList);
            }
        }

        public AddCategoryVM GetAddCategoryVM
        {
            get
            {
                return new AddCategoryVM(GetCategoryList);
            }
        }

        public EditCategoryVM GetEditCategoryVM
        {
            get
            {
                return new EditCategoryVM(GetCategoryList.SelectedItem);
            }
        }

        public EditNinjaVM GetEditNinjaVM
        {
            get
            {
                return new EditNinjaVM(null);
            }
        }

        public EditNinjaVM getEditNinjaVM
        {
            get
            {
                return new EditNinjaVM(GetNinjaList.SelectedItem);
            }
        }

        public EditCategoryVM GetEditCategoryVM
        {
            get
            {
                return new EditCategoryVM(GetCategoryList.SelectedItem);
            }
        }

        public EditEquipmentVM GetEditEquipmentVM
        {
            get
            {
                return new EditEquipmentVM(GetEquipmentList.SelectedItem);
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}