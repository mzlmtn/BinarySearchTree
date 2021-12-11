using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBinarySearchTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _Form1 = this;
        }

        public static Form1 _Form1;

        public int NumberCount = 20;
        public List<int> Numbers = new List<int>();
        public Tree _TREE;
        public string str = "";


        private void button1_Click(object sender, EventArgs e)
        {
            if (Numbers.Count > 0)
            {
                Node r = new Node();
                r.Value = Numbers[0];
                _TREE = new Tree(r);
                for (int i = 1; i < Numbers.Count; i++)
                {
                    Node n = new Node { Value = Numbers[i] };
                    _TREE.AddValue(_TREE.Root, n);
                }
                _TREE.Root.Visit();
            }
            else
            {
                MessageBox.Show("First add some numbers!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                Numbers.Clear();
                NumberCount = int.Parse(textBox1.Text);
                if (NumberCount > 0)
                {
                    Random rnd = new Random();
                    for (int i = 0; i < NumberCount; i++)
                    {
                        int num = rnd.Next(0, 9999);
                        Numbers.Add(num);
                        listBox1.Items.Add(num);
                    }
                    NumberCount = 20;
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Number count cannot be less than 0!");
                }
            }
            else
            {
                MessageBox.Show("Number count cannot be 0!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                textBox1.Text = "";
            }
        }
    }


    public class Tree
    {
        public Node Root;
        public Tree(Node n)
        {
            Root = n;
        }

        public void AddValue(Node current, Node add)
        {
            if (add.Value < current.Value)
            {
                if (current.Left == null)
                {
                    current.Left = add;
                }
                else
                {
                    AddValue(current.Left, add);
                }
            }
            else if (add.Value > current.Value)
            {
                if (current.Right == null)
                {
                    current.Right = add;
                }
                else
                {
                    AddValue(current.Right, add);
                }
            }
            else
            {
                return;
            }
        }
    }

    public class Node
    {
        public Node Left, Right;
        public int Value, X, Y;

        public Node Search(int val)
        {
            if (val == Value)
            {
                return this;
            }
            else if (val < Value && Left != null)
            {
                return Left.Search(val);
            }
            else if (val > Value && Right != null)
            {
                return Right.Search(val);
            }
            return null;
        }
        public void Visit()
        {
            if (Left != null)
            {
                Left.Visit();
            }
            Form1._Form1.listBox2.Items.Add(Value);
            if (Right != null)
            {
                Right.Visit();
            }
        }
    }
}
