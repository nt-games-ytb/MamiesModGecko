using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MamiesModGecko;
using MamiesModGeckoTest;

namespace MamiesModGeckoTest
{
    public partial class Form1 : Form
    {
        private TCPConn Connection;
        private TCPGecko MamiesModGecko;
        private BeforeConnect BeforeConnect = new BeforeConnect();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void ipText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (BeforeConnect.ValidateIPv4(ipText.Text) == true)
                {
                    connect.Enabled = true;
                }
                else
                {
                    connect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                MamiesModGecko = new TCPGecko(ipText.Text);
                MamiesModGecko.simplyConnect();
                GetNintendoNetwork();

                ipText.Enabled = false;
                connect.Enabled = false;
                disconnect.Enabled = true;
                xray.Enabled = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "MamiesModGecko Test");
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("Error: your ip is not the right one or you are not connected to the internet !", "MamiesModGecko Test");
            }
            catch
            {
                MessageBox.Show("An unknown error has occurred !", "MamiesModGecko Test");
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            MamiesModGecko.Disconnect();

            ipText.Enabled = true;
            connect.Enabled = true;
            disconnect.Enabled = false;
            xray.Enabled = false;
        }

        private void xray_CheckedChanged(object sender, EventArgs e)
        {
            if (xray.Checked)
            {
                MamiesModGecko.poke32(0x108F73E0, 0x40000000);
            }
            else
            {
                MamiesModGecko.poke32(0x108F73E0, 0x3F000000);
            }
        }
    }
}
