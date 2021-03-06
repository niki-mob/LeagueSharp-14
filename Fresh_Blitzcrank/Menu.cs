﻿using System;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;


namespace Fresh_Britzcrank
{
    class MainMenu
    {
        public static Menu _MainMenu;
        public static Orbwalking.Orbwalker _OrbWalker;
        public static void Menu()
        {
            try // try start
            {
                _MainMenu = new Menu("FreshBlitzcrank", "FreshBlitzcrank", true).SetFontStyle(System.Drawing.FontStyle.Regular, Color.Aqua); ; ;
                _MainMenu.AddToMainMenu();

                Menu orbwalkerMenu = new Menu("OrbWalker", "OrbWalker");
                _OrbWalker = new Orbwalking.Orbwalker(orbwalkerMenu);
                _MainMenu.AddSubMenu(orbwalkerMenu);

                var targetSelectorMenu = new Menu("Target Selector", "TargetSelector");
                TargetSelector.AddToMenu(targetSelectorMenu);
                _MainMenu.AddSubMenu(targetSelectorMenu);

                var Combo = new Menu("Combo", "Combo");
                {
                    Combo.AddItem(new MenuItem("CUse_Q", "Use Q").SetValue(true));
                    Combo.AddItem(new MenuItem("CUse_W", "Use W").SetValue(true));
                    Combo.AddItem(new MenuItem("CUse_E", "Use E").SetValue(true));
                    Combo.AddItem(new MenuItem("CUse_R", "Use R").SetValue(true));
                    Combo.AddItem(new MenuItem("CUseQ_Hit", "Q HitChance").SetValue(new Slider(6,1,6)));
                    Combo.AddItem(new MenuItem("CKey", "Combo Key").SetValue(new KeyBind(32, KeyBindType.Press)));
                }
                _MainMenu.AddSubMenu(Combo);                

                var Misc = new Menu("Misc", "Misc");
                {                    
                    foreach(var enemy in ObjectManager.Get<Obj_AI_Hero>())
                    {
                        if(enemy.Team != Program.Player.Team)
                        {
                            Misc.SubMenu("SetGrab").AddItem(new MenuItem("GrabSelect" + enemy.ChampionName, enemy.ChampionName)).SetValue(new StringList(new[] { "Enable", "Dont", "Auto" }));
                        }
                    }
                    Misc.SubMenu("Interrupt").AddItem(new MenuItem("InterQ", "Use Q").SetValue(true));
                    Misc.SubMenu("Interrupt").AddItem(new MenuItem("InterE", "Use E").SetValue(true));
                    Misc.SubMenu("Interrupt").AddItem(new MenuItem("InterR", "Use R").SetValue(true));
                }
                _MainMenu.AddSubMenu(Misc);

                var Draw = new Menu("Draw", "Draw");
                {
                    Draw.AddItem(new MenuItem("Draw_Q", "Draw Q").SetValue(false));                    
                    Draw.AddItem(new MenuItem("Draw_R", "Draw R").SetValue(false));
                    Draw.AddItem(new MenuItem("Indicator", "Draw Damage Indicator").SetValue(true));
                }
                _MainMenu.AddSubMenu(Draw);
            } // try end     
            catch (Exception e)
            {
                Console.Write(e);
                Game.PrintChat("FreshBlitzcrank is not working. plz send message by KorFresh (Code 1)");
            }           
            
        }
    }
}
