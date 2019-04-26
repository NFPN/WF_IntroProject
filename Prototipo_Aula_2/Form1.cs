using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo_Aula_2
{
    public partial class frmMove : Form
    {
        private bool paraEsquerda;
        private bool paraDireita;
        private bool paraCima;
        private bool paraBaixo;

        private bool[] dirs = new bool[4];//left,right,up,down
        private string dir = "";
        private int velocidade = 3;

        public frmMove()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void VerifyCollision()
        {
            foreach (Control obj in Controls)
            {
                if(obj is PictureBox && (string)obj.Tag == "Obstacle")
                {
                    if (Player.Bounds.IntersectsWith(obj.Bounds))
                    {
                        if (paraEsquerda && obj.Location.X <= Player.Location.X)
                            LockDirection(0);

                        if (paraDireita && obj.Location.X >= Player.Location.X)
                            LockDirection(1);

                        if (paraCima && obj.Bottom >= Player.Top)
                            LockDirection(2);

                        if (paraBaixo && obj.Top <= Player.Bottom)
                            LockDirection(3);
                    }
                }
            }
        }

        private void LockDirection(int index)
        {
            dirs[index] = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (paraEsquerda && !dirs[0])
            {
                Player.Left -= velocidade;
            }

            if (paraDireita && !dirs[1])
            {
                Player.Left += velocidade;
            }

            if (paraCima && !dirs[2])
            {
                Player.Top -= velocidade;
            }

            if (paraBaixo && !dirs[3])
            {
                Player.Top += velocidade;
            }
        }

        private void frmMove_KeyDown(object sender, KeyEventArgs e)
        {
            VerifyCollision();

            //Se o usuário pressionar a tecla para a esquerda
            if (e.KeyCode == Keys.Left)
            {
                paraEsquerda = true;
            }

            //Se o usuário pressionar a tecla para a direita
            if (e.KeyCode == Keys.Right)
            {
                paraDireita = true;
            }

            //Se o usuário pressionar a tecla para cima
            if (e.KeyCode == Keys.Up)
            {
                paraCima = true;
            }

            //Se o usuário pressionar a tecla para baixo
            if (e.KeyCode == Keys.Down)
            {
                paraBaixo = true;
            }
        }

        private void frmMove_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Utilizando Switch para alterar o valor das variáveis
                case Keys.Left:
                    paraEsquerda = false;
                    break;
                case Keys.Right:
                    paraDireita = false;
                    break;
                case Keys.Up:
                    paraCima = false;
                    break;
                case Keys.Down:
                    paraBaixo = false;
                    break;
            }
        }
    }
}
