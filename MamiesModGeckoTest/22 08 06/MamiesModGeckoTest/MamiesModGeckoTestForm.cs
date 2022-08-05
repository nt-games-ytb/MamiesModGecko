using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MamiesModGecko;
using MamiesModGeckoTest;

namespace MamiesModGeckoTest
{
    public partial class MamiesModGeckoTestForm : Form
    {
        private TCPConn Connection;
        private TCPGecko MamiesModGecko;
        private BeforeConnect BeforeConnect = new BeforeConnect();
        public string nintendoNetwork;

        #region Code Handler
        public List<uint> codesList = new List<uint> {};
        
        bool xrayCode = false;
        #endregion

        public MamiesModGeckoTestForm()
        {
            InitializeComponent();
        }

        private void MamiesModGeckoTestForm_Load(object sender, EventArgs e)
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
                MessageBox.Show("Welcome " + nintendoNetwork + ",\n you are now connected on MamiesModGecko Test !", "MamiesModGecko Test");

                ipText.Enabled = false;
                connect.Enabled = false;
                disconnect.Enabled = true;
                xrayPoke.Enabled = true;
                xrayCodeHandler.Enabled = true;
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
            xrayPoke.Enabled = false;
            xrayCodeHandler.Enabled = false;
        }

        #region Get Nintendo Network
        private void GetNintendoNetwork() //only for Minecraft Wii U
        {
            string text1 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x4C));
            string text2 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x50));
            string text3 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x54));
            string text4 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x58));
            string text5 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x5C));
            string text6 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x60));
            string text7 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x64));
            string text8 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x68));
            string text9 = MamiesModGecko.peekStringUTF16(MamiesModGecko.peek(MamiesModGecko.peek(0x10AD1C58) + 0x68));
            nintendoNetwork = text1 + text2 + text3 + text4 + text5 + text6 + text7 + text8 + text9;
        }
        #endregion

        private void updateCodesListForEnableCodes() //for enable all codes
        {
            codesList.Clear();

            if (xrayCode == true)
            {
                MamiesModGecko.addCodeToCodesList(codesList, "00020000 108F73E0\n40000000 00000000\nD0000000 DEADCAFE");
                // "\n" is a line break | You can also put spaces or put commas

                /*
                or : 
                codesList.Add(0x00020000);
                codesList.Add(0x108F73E0);
                codesList.Add(0x40000000);
                codesList.Add(0x00000000);
                */
            }

            MamiesModGecko.enableCodes(codesList);
        }

        private void updateCodesListForDisableCodes() //for disable codes that need to reset to default
        {
            codesList.Clear();

            if (xrayCode == false)
            {
                MamiesModGecko.addCodeToCodesList(codesList, "00020000 108F73E0\n3F000000 00000000\nD0000000 DEADCAFE");
                // "\n" is a line break | You can also put spaces or put commas

                /*
                or : 
                codesList.Add(0x00020000);
                codesList.Add(0x108F73E0);
                codesList.Add(0x3F000000);
                codesList.Add(0x00000000);
                */
            }

            MamiesModGecko.enableCodes(codesList);
            Thread.Sleep(750);
            MamiesModGecko.disableCodes();
        }

        private void xrayPoke_CheckedChanged(object sender, EventArgs e)
        {
            if (xrayPoke.Checked)
            {
                MamiesModGecko.poke32(0x108F73E0, 0x40000000);
            }
            else
            {
                MamiesModGecko.poke32(0x108F73E0, 0x3F000000);
            }
        }

        private void xrayCodeHandler_CheckedChanged(object sender, EventArgs e)
        {
            if (xrayCodeHandler.Checked)
            {
                xrayCode = true;
                updateCodesListForEnableCodes();
            }
            else
            {
                xrayCode = false;
                updateCodesListForDisableCodes();
            }
        }
    }
}
