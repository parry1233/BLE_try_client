using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarrenLee.Bluetooth;

namespace BLE_try_client
{
	public partial class Form1 : Form
	{
		Bluetooth_Client bleClient = new Bluetooth_Client("DELLXPC-PC");
		public Form1()
		{
			InitializeComponent();
			textStatus.Text = "------";
		}

		private void BtnConnect_Click(object sender, EventArgs e)
		{
			bleClient.Start();
			textStatus.Text = "Trying......";
			bleClient.IsConnected += bleClient_IsConnected;
		}

		private void bleClient_IsConnected(object sender, EventArgs e)
		{
			if (InvokeRequired)
			{
				this.Invoke(new Action(() =>
				{
					textStatus.Text = "Connected";
				}));
			}
		}

		private void BtnSend_Click(object sender, EventArgs e)
		{
			bleClient.SyncMessage(textSend.Text);
			textSend.Text = null;
		}
	}
}
