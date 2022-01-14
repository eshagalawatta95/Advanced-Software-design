using System;
using System.Drawing;
using System.Windows.Forms;
using BudgetMe.Enums;

namespace BudgetMe.Views.UserControls
{
    public partial class MenuItemUserControl : UserControl
    {
        private ContentItemEnum _itemButtonEnum;
        private Action<ContentItemEnum> _action;
        private Image _image;

        public MenuItemUserControl(ContentItemEnum menuItemButtonEnum, 
            Action<ContentItemEnum> menuItemButtonAction, 
            Image menuItemButtonImage,
            string  menuItemButtonText)
        {
            InitializeComponent();
            _itemButtonEnum = menuItemButtonEnum;
            _action = menuItemButtonAction;

            Size menuItemImageSize = new Size(45, 45);
            _image = new Bitmap(menuItemButtonImage, menuItemImageSize);

            Visible = true;
            Enabled = true;
            Name = $"MenuItemUserControl-{(short)menuItemButtonEnum}";
            TabIndex = (int)menuItemButtonEnum;
            menuButton.Text = menuItemButtonText;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            _action(_itemButtonEnum);
        }

        private void MenuItemUserControl_Load(object sender, EventArgs e)
        {
            menuButton.Image = _image;
        }
    }
}
