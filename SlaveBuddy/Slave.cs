using EloBuddy;
using System.IO;
using System.IO.Pipes;

namespace SlaveBuddy
{
	internal class Slave
	{

		StreamReader reader;
		NamedPipeClientStream client = new NamedPipeClientStream("EBSM");
		StreamWriter writer;
		AIHeroClient master;
		public Slave(AIHeroClient master)
		{
			this.master = master;
			reader = new StreamReader(client);
			writer = new StreamWriter(client);
			Game.OnTick += Game_OnTick;
		}

		private void Game_OnTick(System.EventArgs args)
		{
			switch (reader.ReadLine())
			{
				case "move Master":
					Player.IssueOrder(GameObjectOrder.MoveTo, master.Position);
					break;
			}
		}
	}
}