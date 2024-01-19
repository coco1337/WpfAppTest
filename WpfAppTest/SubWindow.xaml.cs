using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppTest
{
  /// <summary>
  /// Interaction logic for SubWindow.xaml
  /// </summary>
  public partial class SubWindow : Window
  {
    private readonly Func<int, int> _dontDoThis;
    public SubWindow(Func<int, int> _getAvailableWindowSlot)
    {
      InitializeComponent();
      _dontDoThis = _getAvailableWindowSlot;
    }
  }
}
