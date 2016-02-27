using EloBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaveBuddy
{
	class Program
	{
		static Master _master = null;
		static Slave _slave = null;
		static void Main(string[] args)
		{
			Chat.OnMessage += Chat_OnMessage;
		}

		private static void Chat_OnMessage(AIHeroClient sender, ChatMessageEventArgs args)
		{
			if(args.Message == "!master")
			{
				if(sender == Player.Instance)
				{
					_master = new Master();
				}
				else
				{
					_slave = new Slave(sender);
				}
			}
		}
	}
}
