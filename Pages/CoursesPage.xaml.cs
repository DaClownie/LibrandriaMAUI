using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages;

public partial class CoursesPage : ContentPage
{
    public CoursesPage(CoursesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}