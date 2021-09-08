using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Controller.Renderers.Templates
{
    public partial class ManyToManyCRUDTemplate : Form
    {
        public ManyToManyCRUDTemplate(string title, Color pageColor, Action<object> movedToRightbuttonClicked, Action<object> moveToLeftButtonClicked)
        {
            InitializeComponent();
            _titleLabel.Text = title;
            _titleLabel.BackColor = pageColor;

            MoveToLeftButtonClicked = moveToLeftButtonClicked;
            MoveToRightButtonClicked = movedToRightbuttonClicked;

            _moveLeftButton.ApplyTheme(pageColor);
            _moveRightButton.ApplyTheme(pageColor);
        }

        public Action<Exception> ErrorMovingLeft { get; set; }
        public Action<Exception> ErrorMovingRight { get; set; }
        public TableLayoutPanel InputsContainer => _inputsContainer;
        public ComboBox LeftComboBox => _leftComboBox;
        public Action<object> MoveToLeftButtonClicked { get; set; }
        public Action<object> MoveToRightButtonClicked { get; set; }
        public int SelectedPrimaryId { get; set; }
        public ComboBox RightComboBox => _rightCombobox;

        private void _moveLeftButton_Click(object sender, EventArgs e)
            => MoveItemBetweenComboBoxes(_rightCombobox, MoveToLeftButtonClicked, _leftComboBox, ErrorMovingLeft);

        private void _moveRightButton_Click(object sender, EventArgs e)
            => MoveItemBetweenComboBoxes(_leftComboBox, MoveToRightButtonClicked, _rightCombobox, ErrorMovingRight);

        private void MoveItemBetweenComboBoxes(ComboBox fromComboBox, Action<object> tryAction, ComboBox toComboBox, Action<Exception> errorAction)
        {
            if (fromComboBox.SelectedIndex == -1)
                return;
            try
            {
                KeyValuePair<int, string> obj = (KeyValuePair<int, string>)fromComboBox.Items[fromComboBox.SelectedIndex];
                tryAction(obj.Key);
                object item = fromComboBox.SelectedItem;
                fromComboBox.Items.Remove(item);
                toComboBox.Items.Add(item);
            }
            catch (Exception err)
            {
                errorAction?.Invoke(err);
            }
        }
    }
}