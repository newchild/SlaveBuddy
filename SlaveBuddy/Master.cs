using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.IO;
using System.IO.Pipes;

namespace SlaveBuddy
{
	internal class Master
	{
		Menu _MasterMenu;
		NamedPipeServerStream server;
		StreamReader reader;
		StreamWriter writer;
		public Master()
		{
			_MasterMenu = MainMenu.AddMenu("Elobuddy Master", "fsduhi");
			_MasterMenu.Add("ebsmMP", new KeyBind("Move slave to master", false, KeyBind.BindTypes.HoldActive, new System.Tuple<uint, uint>('O', 'O')));
			server = new NamedPipeServerStream("EBSM");
			reader = new StreamReader(server);
			writer = new StreamWriter(server);
			Game.OnTick += Game_OnTick;
		}

		private void Game_OnTick(System.EventArgs args)
		{
			if (_MasterMenu["ebsmMP"].Cast<KeyBind>().CurrentValue)
			{
				writer.WriteLine("move Master");
				writer.Flush();
			}
		}
	}
}