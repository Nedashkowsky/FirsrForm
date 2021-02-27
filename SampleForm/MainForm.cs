using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleForm
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Строковые данные
        /// </summary>
        private string data;

        /// <summary>
        /// Храним нажатие
        /// </summary>
        private bool pressed;

        private int x;
        private int y;
        public MainForm()
        {
            // Поддержка дизайнера формы
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик события "Копировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик события "Вставить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                data = Clipboard.GetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Нажатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card1_MouseDown(object sender, MouseEventArgs e)
        {
            pressed = true;
            x = e.X;
            y = e.Y;
        }

        /// <summary>
        /// Отпускаем кнопку мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card1_MouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender">Перемещаемый объект</param>
        /// <param name="e"></param>
        private void card1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (pressed)
                {
                    Control control = (Control)sender;
                    control.Location = new Point(e.X + control.Location.X - x, e.Y + control.Location.Y - y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Создание новой карточки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox text = new TextBox()
            {
                Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204))),
                Location = new Point(0, menuStrip1.Height),
                ReadOnly = true,
                Text = "карточка"
        };
            // Обработчики событий
            text.MouseUp += card1_MouseUp;
            text.MouseDown += card1_MouseDown;
            text.MouseMove += card1_MouseMove;
            // Добавление элемента на форму
            Controls.Add(text);
        }


    }
}
