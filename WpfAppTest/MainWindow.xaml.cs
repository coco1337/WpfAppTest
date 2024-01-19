using System.Windows;

namespace WpfAppTest
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    public const int WINDOW_SLOT = 12;
    public const int POPUP_WIDTH = 320;

    private bool[] _Slot = new bool[WINDOW_SLOT];
    private SubWindow _Class;

    private void ButtonMFRClick(object sender, RoutedEventArgs e)
    {
      _Class ??= new SubWindow(GetAvailableWindowSlot);
      if (!_Class.IsActive)
      {
        int availableSlot = GetAvailableWindowSlot(320);
        _Class.Show();

      }
    }

    public int GetAvailableWindowSlot(int widthWindow)
    {
      int requiredWindowSlot = widthWindow / POPUP_WIDTH;
      int availableSlotCount = 0;
      int availableSlot = 0;
      bool isGetAvailableSlot = false;

      for (int slot = 0; slot < _Slot.Length; slot++)
      {
        if (!_Slot[slot])
        {
          availableSlotCount++;
          if (availableSlotCount >= requiredWindowSlot)
          {
            availableSlot = slot;
            isGetAvailableSlot = true;
            break;
          }
        }
      }

      if (isGetAvailableSlot)
      {
        for (int i = 0; i < requiredWindowSlot; i++)
        {
          _Slot[availableSlot + i] = true;
        }
      }
      else
      {
        availableSlot = -1;
      }

      string strTest = "availableSlot : " + availableSlot.ToString();
      for (int i = 0; i < WINDOW_SLOT; i++)
      {
        strTest += "\n_isPopupWindowSlotOccupied[" + i.ToString() + "] : " + _Slot[i].ToString();
      }

      MessageBox.Show(strTest);
      return availableSlot;
    }
  }
}
