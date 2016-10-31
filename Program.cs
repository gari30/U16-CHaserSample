using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHaser

{
	class Program
	{
		static void Main( string[] args )
		{
			/* おまじない */
			Client c = Client.Create();

			/* 変数宣言 */
			int[] value = new int[9];   //周囲情報
			int mode = 1;
			int old_mode = 1;

			while (true)
			{
				value = c.GetReady();       //GetReady

				/* ここから変更する */

				if (value[1] == 3 || value[3] == 3 || value[5] == 3 || value[7] == 3)
				//上下左右にアイテムがあったら
				{
					old_mode = mode;
					mode = 10;
				}

				switch (mode)
				{
					case 1: //上に移動
						if (value[1] != 2)
						{
							c.wu();
						}
						else
						{
							c.wr();
							mode = 2;
						}
						break;
					case 2:
						if (value[5] != 2)
						{
							c.wr();
						}
						else
						{
							c.wd();
							mode = 3;
						}
						break;

					case 3:
						if (value[7] != 2)
						{
							c.wd();
						}
						else
						{
							c.wl();
							mode = 4;
						}
						break;

					case 4:
						if (value[3] != 2)
						{
							c.wl();
						}
						else
						{
							c.wu();
							mode = 1;
						}
						break;

					case 10:
						if (value[1] == 3)
						{
							c.wu();
						}
						else if (value[5] == 3)
						{
							c.wr();
						}
						else if (value[7] == 3)
						{
							c.wd();
						}
						else if (value[3] == 3)
						{
							c.wl();
						}
						mode = old_mode;
						break;
				}

				/* ここまで */
			}
		}
	}
}
