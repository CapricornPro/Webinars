namespace RelationshipsAndAssociations
{
    using System;

    public class EAIntegration
    {
        public string EA_Connect(EA.Repository Repository)
            => string.Empty;

        public void EA_Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        const string menuHeader = "-&Vztahy a diagramy";
        const string menuItemAbout = "&O add-inu...";

        public object EA_GetMenuItems(EA.Repository Repository, string Location, string MenuName)
        {
            switch (MenuName)
            {
                // Jde o hlavní položku, vrátíme náš název
                case "":
                    return menuHeader;
                // a zde vrátíme všechny naše položky menu
                case menuHeader:
                    string[] subMenus = { menuItemAbout };
                    return subMenus;
            }
            return "";
        }

        public void EA_GetMenuState(EA.Repository Repository, string Location, string MenuName, string ItemName, ref bool IsEnabled, ref bool IsChecked)
        {
            switch (ItemName)
            {
                case menuItemAbout:
                    IsEnabled = true;
                    break;
                default:
                    IsEnabled = false;
                    IsChecked = true;
                    break;
            }
        }

        public void EA_MenuClick(EA.Repository Repository, string Location, string MenuName, string ItemName)
        {

            switch (ItemName)
            {
                case menuItemAbout:
                    AboutAddin();
                    break;
                default:
                    throw new NotImplementedException($"Neobsloužená položka {ItemName} v menu {MenuName}!");
            }
        }

        private void AboutAddin()
            => System.Windows.Forms.MessageBox.Show("Ano, vše funguje.", "O addinu");

    }
}
