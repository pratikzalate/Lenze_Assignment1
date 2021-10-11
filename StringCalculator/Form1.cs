﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void unsetValues()
        {   // It unsets all values of ToolStrip Menu Items and clears result textbox3
            concatToolStripMenuItem.Checked = false;
            compareToolStripMenuItem.Checked = false;
            checkPalindromeToolStripMenuItem.Checked = false;
            ReverseToolStripMenuItem.Checked = false;

            concatToolStripMenuItem.BackColor = Color.AliceBlue;
            compareToolStripMenuItem.BackColor = Color.AliceBlue;
            checkPalindromeToolStripMenuItem.BackColor = Color.AliceBlue;
            ReverseToolStripMenuItem.BackColor = Color.AliceBlue;

            textBox3.Text = "";
        }

        private void concatToolStripMenuItem_Click(object sender, EventArgs e)
        {   // unsetting all values and then setting values for highligting current selection
            this.unsetValues();
            concatToolStripMenuItem.BackColor = Color.DodgerBlue;
            concatToolStripMenuItem.Checked = true;
            // label and textbox for string2 should be visible here
            string2.Visible = true;
            textBox2.Visible = true;
            
            label2_res.Text = "String concatenation result is :";
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.unsetValues();
            compareToolStripMenuItem.BackColor = Color.DodgerBlue;
            compareToolStripMenuItem.Checked = true;

            string2.Visible = true;
            textBox2.Visible = true;

            label2_res.Text = "String equality check result is :";
        }

        private void checkPalindromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.unsetValues();
            checkPalindromeToolStripMenuItem.BackColor = Color.DodgerBlue;
            checkPalindromeToolStripMenuItem.Checked = true;
            // Make string2 label and textbox invisible
            string2.Visible = false;
            textBox2.Visible = false;

            label2_res.Text = "String Palindrome check result is :";
        }

        private void ReverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.unsetValues();
            ReverseToolStripMenuItem.BackColor = Color.DodgerBlue;
            ReverseToolStripMenuItem.Checked = true;
            // Make string2 label and textbox invisible
            string2.Visible = false;
            textBox2.Visible = false;

            label2_res.Text = "Reverse of the string is :";
        }
        private bool isValid(string s1)
        {// Checks whether string is not empty(valid) or empty(invalid)
            if (s1 == "")
                return false;
            return true;
        } 
        private string concatenation(string s1, string s2)
        {// function to concat two input strings
            return string.Concat(s1, s2);
        }
        private bool compare(string s1, string s2)
        {// function to compare two input strings
            return string.Equals(s1,s2);
        }
        private bool isPalindrome(string s1)
        {// function to check input string is palindrome or not
            string rs1 = this.reverse(s1);
            return string.Equals(s1, rs1);
        }
        private string reverse(string s1)
        {// function to reverse the string
            string rs="";
            char ch = s1[0];
            for (int i = (s1.Length - 1) ; i >= 0; --i){
                rs = string.Concat(rs,s1[i].ToString());
            }
            return rs;
        }
        private void result_btn_Click(object sender, EventArgs e)
        {
            string s1, s2;
            s1 = textBox1.Text;
            if (!isValid(s1))
            {// If string1 is empty show Error message
                MessageBox.Show("Please enter string 1.","Error");
                return;
            }
            if (concatToolStripMenuItem.Checked)
            {
                s2 = textBox2.Text;
                if (!isValid(s2))
                {// If string2 is empty show Error message
                    MessageBox.Show("Please enter string 2.","Error");
                    return;
                }
                textBox3.Text = this.concatenation(s1, s2);
            } 
            else if (compareToolStripMenuItem.Checked)
            {
                s2 = textBox2.Text;
                if (!isValid(s2))
                {
                    MessageBox.Show("Please enter string 2.","Error");
                    return;
                }
                textBox3.Text = this.compare(s1, s2).ToString();
            }
            else if (checkPalindromeToolStripMenuItem.Checked)
            {
                textBox3.Text = this.isPalindrome(s1).ToString();
            }
            else if (ReverseToolStripMenuItem.Checked)
            {
                textBox3.Text = this.reverse(s1).ToString();
            }
            else
            {// This means user have not selected any string operation ToolStripItem
                MessageBox.Show("Please select valid string operation.", "Error");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {// If result overflow occure then increase textbox height
            if (textBox3.TextLength > 18)
                textBox3.Height = 60;
            else
                textBox3.Height = 25;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {// Clear all textboxes
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
